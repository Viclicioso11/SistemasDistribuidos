using Application.Common.Pager;
using Application.UserActions.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserById(int userId);

        public Task<User> UpdateUser(User user);

        public Task<bool> DeleteUsers(List<int> ids);

        public Task<int> CreateUser(User user);

        public Task<GenericPager<UserDto>> GetAllUser(string filterBy, int page, int recordsByPage);

        public Task<int> AuthenticateUser(string email, string password);

        public Task<int> AnswerToken(string otp, int tfaId);

    }
}
