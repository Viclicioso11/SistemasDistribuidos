﻿using Application.Common.Interfaces;
using Application.Common.Pager;
using Application.UserActions.Dtos;
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

        public async Task<GenericPager<UserDto>> GetAllUser(string filterBy, int page, int recordsByPage)
        {
 
            var information = new GenericPager<UserDto>();

            information.ActualPage = page;
            information.RecordsByPage = recordsByPage;        
            

            if (string.IsNullOrEmpty(filterBy))
            {
                information.Results = await _context.Users
                    .Skip((page - 1) * recordsByPage)
                    .Take(recordsByPage)
                    .Where(u => u.Status == true)
                    .Select(u => new UserDto
                    {
                        Email = u.Email,
                        Names = u.Names,
                        Identification = u.Identification,
                        LastNames = u.LastNames,
                        Status = u.Status,
                        Id = u.Id

                    })
                    .ToListAsync();

                information.TotalRecords = _context.Users.Count();
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;
            }
            else
            {
                
                information.Results = await _context.Users
                    .Skip((page - 1) * recordsByPage)
                    .Take(recordsByPage)
                    .Where(u => (u.Names.Contains(filterBy) ||
                            u.LastNames.Contains(filterBy) ||
                            u.Identification.Contains(filterBy)) &&
                            u.Status == true)
                    .Select(u => new UserDto
                    {
                        Email = u.Email,
                        Names = u.Names,
                        Identification = u.Identification,
                        LastNames = u.LastNames,
                        Status = u.Status,
                        Id = u.Id
                    })
                    .ToListAsync();

                information.TotalRecords = information.Results.Count();
                information.Results = information.Results.Skip((page - 1) * recordsByPage).Take(recordsByPage).ToList(); // para la paginacion
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;
            }

            return information;
        }

        public async Task<User> GetUserById(int userId)
        {
           var user = await _context.Users.Where(u => u.Status == true && u.Id == userId).FirstOrDefaultAsync();

            if (user != null)
                return user;

            return null;
        }

        public async Task<User> UpdateUser(User user)
        {
            var userToEdit = _context.Users.Find(user.Id);

            userToEdit.Names = user.Names;
            userToEdit.LastNames = user.LastNames;
            userToEdit.Email = user.Email;

            _context.Users.Update(userToEdit);

            var result = await _context.SaveChangesAsync();

            if (result != 0)
                return user;

            return null;
        }

        public async Task<int> AuthenticateUser(string email, string password)
        {
            var auth = await _context.Users.Where(u => u.Email.Equals(email) && u.Password.Equals(password) && u.Status == true).FirstOrDefaultAsync();

            if (auth != null)
                return auth.Id;

            return 0;

        }

        public Task<int> AnswerToken(string otp, int tfaId)
        {
            throw new NotImplementedException();
        }



    }
}
