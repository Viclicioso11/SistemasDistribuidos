﻿using System.Threading.Tasks;
using Application.CandidateActions.Commands;
using Application.CandidateActions.Querys;
using Application.Common.Exceptions;
using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;


namespace BaseArquitecturaAPI.Controllers
{
    [Route("api/candidate/")]
    public class CandidateController : BaseController
    {

        private readonly IMapper _mapper;
        public CandidateController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllCandidates(int page =1 , string filter = "", int records = 10)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var candidates = await Mediator.Send(new GetAllCandidatesQuery { ActualPage = page, FilterBy = filter, RecordsByPage = records });

            if (candidates == null)
                return NotFound();

            return Ok(candidates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var candidate = await Mediator.Send(new GetCandidateByIdQuery { Id = id });

            if (candidate == null)
                return NotFound();

            return Ok(candidate) ;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdateCandidate([FromBody] CandidateModelJson body, [FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            body.Id = id;
            var response = await Mediator.Send(new UpdateCandidateCommand { Candidate = _mapper.Map<Candidate>(body) });

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpPost()]
        public async Task<IActionResult> PostCreateCandidate([FromBody] CandidateModelJson body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var response = await Mediator.Send(new CreateCandidateCommand { Candidate = _mapper.Map<Candidate>(body) });

            if(response !=null)
                return Ok(response);

            return BadRequest();
        }

    }
}
