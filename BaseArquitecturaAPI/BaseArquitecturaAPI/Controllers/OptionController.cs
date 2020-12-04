using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.OptionActions.Commands;
using Application.OptionActions.Querys;
using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BaseArquitecturaAPI.Controllers
{
    [Route("api/option/")]
    public class OptionController : BaseController
    {

        private readonly IMapper _mapper;
        public OptionController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllOptions(int page =1 , string filter = "", int records = 10)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var options = await Mediator.Send(new GetAllOptionsQuery { ActualPage = page, FilterBy = filter, RecordsByPage = records });

            if (options == null)
                return NotFound();

            return Ok(options);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOptionById(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var option = await Mediator.Send(new GetOptionByIdQuery { Id = id });

            if (option == null)
                return NotFound();

            return Ok(option) ;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdateOption([FromBody] OptionModelJson body, [FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            body.Id = id;
            var response = await Mediator.Send(new UpdateOptionCommand { Option = _mapper.Map<Option>(body) });

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpPost()]
        public async Task<IActionResult> PostCreateRol([FromBody] OptionModelJson body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var response = await Mediator.Send(new CreateOptionCommand { Option = _mapper.Map<Option>(body) });

            if(response !=null)
                return Ok(response);

            return BadRequest();
        }
        [HttpDelete()]
        public async Task<IActionResult> DeleteRol([FromBody] DeleteModelJson body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var response = await Mediator.Send(new DeleteOptionCommand { Ids = body.Ids });

            if (response)
                return Ok(response);

            return BadRequest();
        }

    }
}
