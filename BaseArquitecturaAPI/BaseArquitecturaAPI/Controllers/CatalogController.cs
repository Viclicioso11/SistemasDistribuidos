using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CatalogActions.Querys;
using Application.Common.Exceptions;
using Application.UserActions.Commands;
using Application.UserActions.Querys;
using Application.VotationActions.Commands;
using Application.VotationActions.Querys;
using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseArquitecturaAPI.Controllers
{
    [Route("api/catalog/")]
    public class CatalogController : BaseController
    {
        private readonly IMapper _mapper;
        public CatalogController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("city/{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var city = await Mediator.Send(new GetCityByIdQuery { Id = id });

            if (city == null)
                return NotFound();

            return Ok(city);
        }

        [HttpGet("city")]
        public async Task<IActionResult> GetAllCities(int page = 1, string filter = "", int records = 10)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var cities = await Mediator.Send(new GetAllCitiesQuery { ActualPage = page, FilterBy = filter, RecordsByPage = records, UserId = int.Parse(userId) });

            if (cities == null)
                return NotFound();

            return Ok(cities);
        }


        [HttpGet("country/{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var country = await Mediator.Send(new GetCountryByIdQuery { Id = id });

            if (country == null)
                return NotFound();

            return Ok(country);
        }

        [HttpGet("country")]
        public async Task<IActionResult> GetAllCountries(int page = 1, string filter = "", int records = 10)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var cities = await Mediator.Send(new GetAllCountriesQuery { ActualPage = page, FilterBy = filter, RecordsByPage = records });

            if (cities == null)
                return NotFound();

            return Ok(cities);
        }

        [HttpGet("state/{id}")]
        public async Task<IActionResult> GetStateById(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var state = await Mediator.Send(new GetStateByIdQuery { Id = id });

            if (state == null)
                return NotFound();

            return Ok(state);
        }

        [HttpGet("state")]
        public async Task<IActionResult> GetAllStates(int page = 1, string filter = "", int records = 10)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var cities = await Mediator.Send(new GetAllStatesQuery { ActualPage = page, FilterBy = filter, RecordsByPage = records });

            if (cities == null)
                return NotFound();

            return Ok(cities);
        }


    }
}
