﻿using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.VotationActions.Commands;
using Application.VotationActions.Querys;
using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BaseArquitecturaAPI.Controllers
{
    [Route("api/votation/")]
    public class VotationController : BaseController
    {

        private readonly IMapper _mapper;
        public VotationController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllVotations(int page = 1, string filter = "", int records = 10)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var users = await Mediator.Send(new GetAllVotationsQuery { ActualPage = page, FilterBy = filter, RecordsByPage = records });

            if (users == null)
                return NotFound();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVotationById(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var votation = await Mediator.Send(new GetVotationByIdQuery { VotationId = id });

            return Ok(votation);
        }


        [HttpPut()]
        public async Task<IActionResult> PutUpdateVotation([FromBody] VotationModelJson body, [FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var response = await Mediator.Send(new UpdateVotationCommand { Votation = _mapper.Map<Votation>(body) });

            return Ok(response);
        }

        [HttpPut("{id}/status/{status}")]
        public async Task<IActionResult> PutUpdateVotationStatus([FromRoute] bool status, [FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var response = await Mediator.Send(new UpdateVotationStatusCommand { VotationId = id, VotationStatus = status });

            return Ok(response);
        }


        [HttpPost()]
        public async Task<IActionResult> PostCreateVotation([FromBody] VotationModelJson body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var response = await Mediator.Send(new CreateVotationCommand {Votation = _mapper.Map<Votation>(body), Candidates = body.Candidates});

            return Ok(response);
        }

    }
}
