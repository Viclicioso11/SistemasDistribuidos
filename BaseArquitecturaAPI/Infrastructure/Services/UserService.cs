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
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;
        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUser(User user)
        {
            _context.Add(user);

            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteUsers(List<int> ids)
        {
            foreach(var id in ids)
            {
                var user = _context.Users.Find(id);

                user.Status = false;

                _context.Update(user);
            }
            
            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return false;

            return true;
        }

        public async Task<User> GetUserById(int userId)
        {
           var user = await _context.Users.Where(u => u.Status == true && u.UserId == userId).FirstOrDefaultAsync();

            if (user != null)
                return user;

            return null;
        }

        public async Task<User> UpdateUser(User user)
        {
            var userToEdit = _context.Users.Find(user.UserId);

            userToEdit.FirstName = user.FirstName;
            userToEdit.LastName = user.LastName;
            userToEdit.MiddleName = user.MiddleName;
            userToEdit.Surname = user.Surname;
            userToEdit.Email = user.Email;

            _context.Users.Update(userToEdit);

            var result = await _context.SaveChangesAsync();

            if (result != 0)
                return user;

            return null;
        }

    }
}
