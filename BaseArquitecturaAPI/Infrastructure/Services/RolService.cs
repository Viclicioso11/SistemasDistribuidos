using Application.Common.Interfaces;
using Application.Common.Pager;
using Application.OptionActions.Dtos;
using Application.RolActions.Dtos;
using Application.RolOptionActions.Dtos;
using Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RolService : IRolService
    {
        private readonly DatabaseContext _context;
        public RolService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateRol(Rol rol)
        {
            _context.Add(rol);

            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteRols(List<int> ids)
        {
            foreach (var id in ids)
            {
                var rol = _context.Rols.Find(id);

                // eliminar los registros de rol opciones primero

                var optionsRols = _context.RolOptions.Where(op => op.RolId == rol.Id);

                foreach (var optionRol in optionsRols)
                {
                    _context.RolOptions.Remove(optionRol);
                }

                _context.Rols.Remove(rol);

            }

            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }

        public async Task<GenericPager<RolDto>> GetAllRols(string filterBy, int page, int recordsByPage)
        {
            var information = new GenericPager<RolDto>();

            information.ActualPage = page;
            information.RecordsByPage = recordsByPage;


            if (string.IsNullOrEmpty(filterBy))
            {
                information.Results = await _context.Rols
                    .Skip((page - 1) * recordsByPage)
                    .Take(recordsByPage)
                    .Select(r => new RolDto
                    {
                        RolName = r.RolName,
                        Id = r.Id

                    })
                    .ToListAsync();

                information.TotalRecords = _context.Rols.Count();
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;

                information.Next = page < information.TotalPages;
                information.Previous = page > 1;
            }
            else
            {

                information.Results = await _context.Rols
                    .Skip((page - 1) * recordsByPage)
                    .Take(recordsByPage)
                    .Where(r => (r.RolName.Contains(filterBy)))
                    .Select(r => new RolDto
                    {
                        RolName = r.RolName,
                        Id = r.Id

                    })
                    .ToListAsync();

                information.TotalRecords = information.Results.Count();
                information.Results = information.Results.Skip((page - 1) * recordsByPage).Take(recordsByPage).ToList(); // para la paginacion
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;

                information.Next = page < information.TotalPages;
                information.Previous = page > 1;
            }

            return information;
        }

        public async Task<RolDto> GetRolById(int rolId)
        {
            var rol = await (from r in _context.Rols
                             where r.Id == rolId
                             select new RolDto
                             {
                                 Id = r.Id,
                                 RolName = r.RolName

                             }).FirstOrDefaultAsync();
            if (rol != null)
            {
                rol.RolOptions = (from rp in _context.RolOptions
                                  where rp.RolId == rolId
                                  join op in _context.Options
                                  on rp.OptionId equals op.Id
                                  select new OptionDto
                                  {
                                      Id = op.Id,
                                      OptionDescription = op.OptionDescription,
                                      OptionName = op.OptionName
                                  }).ToList();

                return rol;
            }

            return null;
        }

        public async Task<Rol> UpdateRol(Rol rol)
        {
            var rolToEdit = _context.Rols.Find(rol.Id);

            if (rolToEdit == null)
                return null;

            rolToEdit.RolName = rol.RolName;
           
            _context.Rols.Update(rolToEdit);

            var result = await _context.SaveChangesAsync();

            if (result != 0)
                return rol;

            return null;
        }
    }
}
