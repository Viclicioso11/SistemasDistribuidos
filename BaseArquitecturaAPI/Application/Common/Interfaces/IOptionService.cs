using Application.Common.Pager;
using Application.OptionActions.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IOptionService
    {
        public Task<Option> GetOptionById(int optionId);

        public Task<Option> UpdateOption(Option option);

        public Task<bool> CreateOption(Option option);

        public Task<bool> DeleteOptions(List<int> ids);

        public Task<GenericPager<OptionDto>> GetAllOptions(string filterBy, int page, int recordsByPage);
    }
}
