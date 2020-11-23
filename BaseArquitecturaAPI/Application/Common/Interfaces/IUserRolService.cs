using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IUserRolService
    {
        public Task<bool> CreateUserRol(int userId, List<int> rolIds);

        public Task<bool> DeleteUserRol(int userId, int rolId);
    }
}
