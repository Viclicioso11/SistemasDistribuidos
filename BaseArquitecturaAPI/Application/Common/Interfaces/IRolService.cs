using Application.Common.Pager;
using Application.RolActions.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IRolService
    {
        public Task<RolDto> GetRolById(int rolId);

        public Task<Rol> UpdateRol(Rol rol);

        public Task<bool> CreateRol(Rol rol);

        public Task<bool> DeleteRols(List<int> ids);

        public Task<GenericPager<RolDto>> GetAllRols(string filterBy, int page, int recordsByPage);
    }
}
