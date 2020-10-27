using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UserActions.Commands;
using Application.UserActions.Querys;
using Application.VotationActions.Commands;
using Application.VotationActions.Querys;
using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseArquitecturaAPI.Controllers
{
    [Route("api/user")]
    public class CatalogController : BaseController
    {

        private readonly IMapper _mapper;
        public CatalogController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await Mediator.Send(new GetUserByIdQuery { Id = id });

            if (user == null)
                return NotFound();

            return Ok(user) ;
        }


    }
}
