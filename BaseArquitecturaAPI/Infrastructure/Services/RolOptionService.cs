using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RolOptionService : IRolOptionService
    {
        private readonly DatabaseContext _context;
        public RolOptionService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateRolOption(int idRol, List<int> optionsId)
        {
            var rol = _context.Rols.Find(idRol);

            if (rol == null)
                return false;

            foreach (var optId in optionsId)
            {
                var option = _context.Options.Find(optId);

                if (option == null)
                    return false;

                var rolOption = new RolOption { OptionId = optId, RolId = idRol };
                _context.Add(rolOption);
            }
           
            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteRolOption(List<RolOption> rolOptions)
        { 
            foreach (var rop in rolOptions)
            {
                // se valida la existencia de ambos para poder eliminarlos
                var rol = _context.Rols.Find(rop.RolId);

                if (rol == null)
                    return false;

                var option = _context.Options.Find(rop.OptionId);

                if (option == null)
                    return false;

                var rolOption = _context.RolOptions.Where(rp => rp.RolId == rop.RolId && rp.OptionId == rop.OptionId).FirstOrDefault();

                _context.Remove(rolOption);
            }

            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }
    }
}
