using Application.CatalogActions.Dtos;
using Application.Common.Pager;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICatalogService
    {
        public Task<CityDto> GetCityById(int cityId);
        public Task<CountryDto> GetCountryById(int countryId);
        public Task<StateDto> GetStateById(int stateId);

        public Task<GenericPager<CityDto>> GetAllCities(string filterBy, int page, int recordsByPage);
        public Task<GenericPager<CountryDto>> GetAllCountries(string filterBy, int page, int recordsByPage);
        public Task<GenericPager<StateDto>> GetAllStates(string filterBy, int page, int recordsByPage);
    }
}
