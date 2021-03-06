﻿using Application.CatalogActions.Dtos;
using Application.Common.Interfaces;
using Application.Common.Pager;
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
    public class CatalogService : ICatalogService
    {
        private readonly DatabaseContext _context;
        public CatalogService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<GenericPager<CityDto>> GetAllCities(string filterBy, int page, int recordsByPage)
        {
            var information = new GenericPager<CityDto>(); 

            information.ActualPage = page;
            information.RecordsByPage = recordsByPage;

            if (string.IsNullOrEmpty(filterBy))
            {
                information.Results = await 
                    ( 
                    from c in _context.Cities
                    join s in _context.States
                    on c.StateId equals s.Id
                    select new CityDto
                    {
                        CityCode = c.CityCode,
                        CityId = c.Id,
                        CityName = c.CityName,
                        StateId = s.Id,
                        StateName = s.StateName
                    })
                    .Skip((page - 1) * recordsByPage)
                    .Take(recordsByPage)
                    .ToListAsync();

                information.TotalRecords = _context.Cities.Count();
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;

                information.Next = page < information.TotalPages;
                information.Previous = page > 1;
            }
            else
            {
                information.Results = await
                    (
                    from c in _context.Cities
                    join s in _context.States
                    on c.StateId equals s.Id
                    where c.CityName.Contains(filterBy) || c.CityCode.Contains(filterBy)
                    select new CityDto
                    {
                        CityCode = c.CityCode,
                        CityId = c.Id,
                        CityName = c.CityName,
                        StateId = s.Id,
                        StateName = s.StateName
                    })
                    .ToListAsync();


                information.TotalRecords = information.Results.Count();
                information.Results = information.Results.Skip((page - 1) * recordsByPage).Take(recordsByPage).ToList(); // para la paginacion
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;

                information.Next = page < information.TotalPages;
                information.Previous = page > 1;
            }

            return information;

        }

        public async Task<GenericPager<CountryDto>> GetAllCountries(string filterBy, int page, int recordsByPage)
        {
            var information = new GenericPager<CountryDto>();

            information.ActualPage = page;
            information.RecordsByPage = recordsByPage;

            if (string.IsNullOrEmpty(filterBy))
            {
                information.Results = await
                    (
                    from c in _context.Countries
                    select new CountryDto
                    {
                        CountryId = c.Id,
                        CountryName = c.CountryName
                    })
                    .Skip((page - 1) * recordsByPage)
                    .Take(recordsByPage)
                    .ToListAsync();

                information.TotalRecords = _context.Countries.Count();
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;

                information.Next = page < information.TotalPages;
                information.Previous = page > 1;
            }
            else
            {
                information.Results = await
                    (
                    from c in _context.Countries
                    where c.CountryName.Contains(filterBy)
                    select new CountryDto
                    {
                        CountryId = c.Id,
                        CountryName = c.CountryName
                    })
                    .ToListAsync();

                information.TotalRecords = information.Results.Count();
                information.Results = information.Results.Skip((page - 1) * recordsByPage).Take(recordsByPage).ToList(); // para la paginacion
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;

                information.Next = page < information.TotalPages;
                information.Previous = page > 1;
            }

            return information;
        }

        public async Task<GenericPager<StateDto>> GetAllStates(string filterBy, int page, int recordsByPage)
        {
            var information = new GenericPager<StateDto>();

            information.ActualPage = page;
            information.RecordsByPage = recordsByPage;

            if (string.IsNullOrEmpty(filterBy))
            {
                information.Results = await
                    (
                    from s in _context.States
                    join c in _context.Countries
                    on s.CountryId equals c.Id
                    select new StateDto
                    {
                        StateName = s.StateName,
                        StateId = s.Id,
                        CountryId = c.Id,
                        CountryName = c.CountryName
                    })
                    .Skip((page - 1) * recordsByPage)
                    .Take(recordsByPage)
                    .ToListAsync();

                information.TotalRecords = _context.States.Count();
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;

                information.Next = page < information.TotalPages;
                information.Previous = page > 1;
            }
            else
            {
                information.Results = await
                    (
                    from s in _context.States
                    join c in _context.Countries
                    on s.CountryId equals c.Id
                    where s.StateName.Contains(filterBy)
                    select new StateDto
                    {
                        StateName = s.StateName,
                        StateId = s.Id,
                        CountryId = c.Id,
                        CountryName = c.CountryName
                    })
                    .ToListAsync();

                information.TotalRecords = information.Results.Count();
                information.Results = information.Results.Skip((page - 1) * recordsByPage).Take(recordsByPage).ToList(); // para la paginacion
                information.TotalPages = information.TotalRecords != 0 ? (int)Math.Ceiling((double)information.TotalRecords / recordsByPage) : 0;

                information.Next = page < information.TotalPages;
                information.Previous = page > 1;
            }

            return information;
        }

        public async Task<CityDto> GetCityById(int cityId)
        {
            var city = await (from c in _context.Cities
                              join s in _context.States
                              on c.StateId equals s.Id
                              where c.Id == cityId
                              select new CityDto
                              {
                                  CityCode = c.CityCode,
                                  CityId = c.Id,
                                  CityName = c.CityName,
                                  StateId = s.Id,
                                  StateName = s.StateName

                              }).FirstOrDefaultAsync();

            if (city != null)
                return city;

            return null;
        }

        public async Task<CountryDto> GetCountryById(int countryId)
        {
            var country = await (from c in _context.Countries
                                 where c.Id == countryId
                                 select new CountryDto
                                 {
                                     CountryId = c.Id,
                                     CountryName = c.CountryName

                                 }).FirstOrDefaultAsync();
            if(country != null)
            {
                country.States = from s in _context.States where s.CountryId == countryId
                                 select new StateDto
                                 {
                                     StateName = s.StateName,
                                     StateId = s.Id,
                                     CountryId = country.CountryId,
                                     CountryName = country.CountryName
                                 };

                return country;
            }

            return null;
        }

        public async Task<StateDto> GetStateById(int stateId)
        {
            var state = await(from s in _context.States
                              where s.Id == stateId
                              join c in _context.Countries
                              on s.CountryId equals c.Id
                              select new StateDto
                                {
                                    StateId = s.Id,
                                    StateName = s.StateName,
                                    CountryId = c.Id,
                                    CountryName = c.CountryName

                                }).FirstOrDefaultAsync();

            if (state != null)
            {
                state.Cities = from c in _context.Cities
                               where c.StateId == state.StateId
                               select new CityDto
                               {
                                   CityCode = c.CityCode,
                                   CityName = c.CityName,
                                   StateName = state.StateName,
                                   CityId = c.Id,
                                   StateId = state.StateId
                               };

                return state;
            }

            return null;
        }
    }
}
