using Application.Common.Interfaces;
using Application.Common.Pager;
using Application.OptionActions.Dtos;
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
    public class OptionService : IOptionService
    {
        private readonly DatabaseContext _context;
        public OptionService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateOption(Option option)
        {
            _context.Add(option);

            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteOptions(List<int> ids)
        {
            foreach (var id in ids)
            {
                var option = _context.Options.Find(id);

                // eliminar los registros de rol opciones primero

                var optionsRols = _context.RolOptions.Where(op => op.OptionId == option.Id);

                foreach(var optionRol in optionsRols)
                {
                    _context.RolOptions.Remove(optionRol);
                }

                _context.Options.Remove(option);

            }

            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }

        public async Task<GenericPager<OptionDto>> GetAllOptions(string filterBy, int page, int recordsByPage)
        {
            var information = new GenericPager<OptionDto>();

            information.ActualPage = page;
            information.RecordsByPage = recordsByPage;


            if (string.IsNullOrEmpty(filterBy))
            {
                information.Results = await _context.Options
                    .Skip((page - 1) * recordsByPage)
                    .Take(recordsByPage)
                    .Select(o => new OptionDto
                    {
                        OptionDescription = o.OptionDescription,
                        OptionName = o.OptionName,
                        Id = o.Id

                    })
                    .ToListAsync();

                information.TotalRecords = _context.Options.Count();
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;

                information.Next = page < information.TotalPages;
                information.Previous = page > 1;
            }
            else
            {

                information.Results = await _context.Options
                    .Skip((page - 1) * recordsByPage)
                    .Take(recordsByPage)
                    .Where(o => (o.OptionName.Contains(filterBy) ||
                            o.OptionDescription.Contains(filterBy)))
                    .Select(o => new OptionDto
                    {
                        OptionDescription = o.OptionDescription,
                        OptionName = o.OptionName,
                        Id = o.Id
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

        public async Task<Option> GetOptionById(int optionId)
        {
            var option = await _context.Options.Where(o => o.Id == optionId).FirstOrDefaultAsync();

            if (option != null)
                return option;

            return null;
        }

        public async Task<Option> UpdateOption(Option option)
        {
            var optionToEdit = _context.Options.Find(option.Id);

            if (optionToEdit == null)
                return null;

            optionToEdit.OptionName = option.OptionName;
            optionToEdit.OptionDescription = option.OptionDescription;

            _context.Options.Update(optionToEdit);

            var result = await _context.SaveChangesAsync();

            if (result != 0)
                return option;

            return null;
        }
    }
}
