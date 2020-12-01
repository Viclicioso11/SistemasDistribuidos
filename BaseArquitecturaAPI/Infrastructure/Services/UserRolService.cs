using Application.Common.Interfaces;
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
    public class UserRolService : IUserRolService
    {
        private readonly DatabaseContext _context;
        public UserRolService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateUserRol(int userId, List<int> rolIds)
        {
            var user = _context.Users.Find(userId);

            if (user == null)
                return false;

            foreach (var rolId in rolIds)
            {
                var rol = _context.Rols.Find(rolId);

                if (rol == null)
                    return false;

                var userRol = new UserRol { UserId = userId, RolId = rolId };
                _context.Add(userRol);
            }

            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteUserRol(int userId, int rolId)
        {

            // se valida la existencia de ambos para poder eliminarlos
            var user = _context.Users.Find(userId);

            if (user == null)
                return false;

            var rol = _context.Rols.Find(rolId);

            if (rol == null)
                return false;

            var userRol = _context.UserRols.Where(ur => ur.UserId == userId && ur.RolId == rolId).FirstOrDefault();

            _context.Remove(userRol);


            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }

        public async Task<Rol> GetRolByUserId(int userId)
        {
            var rol = await (from ur in _context.UserRols
                             join r in _context.Rols
                             on ur.RolId equals r.Id
                             where ur.UserId == userId
                             select new Rol
                             {
                                 RolName = r.RolName
                             }).FirstOrDefaultAsync();

            return rol;
        }
    }
}
