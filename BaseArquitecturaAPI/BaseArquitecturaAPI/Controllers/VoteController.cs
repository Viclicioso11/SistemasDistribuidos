using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.VoteActions.Commands;
using Application.VoteActions.Querys;
using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BaseArquitecturaAPI.Controllers
{
    [Route("api/vote/")]
    public class VoteController : BaseController
    {

        private readonly IMapper _mapper;
        public VoteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("votation/{id}")]
        public async Task<IActionResult> GetVotesCountByVotationId(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var votation = await Mediator.Send(new GetVotesCountByVotationIdQuery { VotationId = id });

            return Ok(votation);
        }


        [HttpPost()]
        public async Task<IActionResult> PostCreateVote([FromBody] VoteModelJson body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var response = await Mediator.Send(new CreateVoteCommand {Vote = _mapper.Map<Vote>(body)});

            return Ok(response);
        }

    }
}
