using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.PoliticalPartyActions.Commands;
using Application.PoliticalPartyActions.Querys;
using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseArquitecturaAPI.Controllers
{
    [Route("api/political-party/")]
    public class PoliticalPartyController : BaseController
    {

        private readonly IMapper _mapper;
        public PoliticalPartyController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllPoliticalParties(int page =1 , string filter = "", int records = 10)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var politicalParties = await Mediator.Send(new GetAllPoliticalPartiesQuery { ActualPage = page, FilterBy = filter, RecordsByPage = records });

            if (politicalParties == null)
                return NotFound();

            return Ok(politicalParties);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPoliticalPartyById(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var politicalParty = await Mediator.Send(new GetPoliticalPartyByIdQuery { Id = id });

            if (politicalParty == null)
                return NotFound();

            return Ok(politicalParty) ;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdatePoliticalParty([FromBody] PoliticalPartyModelJson body, [FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            body.Id = id;
            var response = await Mediator.Send(new UpdatePoliticalPartyCommand { PoliticalParty = _mapper.Map<PoliticalParty>(body) });

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpPost()]
        public async Task<IActionResult> PostCreatePoliticalParty([FromBody] PoliticalPartyModelJson body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var response = await Mediator.Send(new CreatePoliticalPartyCommand { PoliticalParty = _mapper.Map<PoliticalParty>(body) });

            if(response !=null)
                return Ok(response);

            return BadRequest();
        }

    }
}
