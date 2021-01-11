using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IRolOptionService
    {
        public Task<bool> CreateRolOption(int idRol, List<int> optionsId);

        public Task<bool> DeleteRolOption(List<RolOption> rolOptions);
    }
}
