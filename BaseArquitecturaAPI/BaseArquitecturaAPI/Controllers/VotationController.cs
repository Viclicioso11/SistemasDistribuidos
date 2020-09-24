using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.VotationActions.Commands;
using Application.VotationActions.Querys;
using AutoMapper;
using BaseArquitecturaAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseArquitecturaAPI.Controllers
{
    [Route("api/votation")]
    public class VotationController : BaseController
    {

        private readonly IMapper _mapper;
        public VotationController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVotationById(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var votation = await Mediator.Send(new GetVotationByIdQuery { VotationId = id });

            return Ok(votation);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdateVotation([FromBody] VotationModelJson body, [FromRoute]int id)
        {
            /*
             * TO DO
             * 
             */

            return Ok();
        }


        [HttpPost()]
        public async Task<IActionResult> PostCreateVotation([FromBody] VotationModelJson body)
        {
            if (body == null)
                return BadRequest();
            var response = await Mediator.Send(_mapper.Map<VotationCommand>(body));

            return Ok(response);
        }

    }
}
