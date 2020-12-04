using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.RolActions.Commands;
using Application.RolActions.Querys;
using Application.RolOptionActions.Commands;
using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseArquitecturaAPI.Controllers
{
    [Route("api/rol/")]
    public class RolController : BaseController
    {

        private readonly IMapper _mapper;
        public RolController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllRols(int page = 1, string filter = "", int records = 10)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var rols = await Mediator.Send(new GetAllRolsQuery { ActualPage = page, FilterBy = filter, RecordsByPage = records });

            if (rols == null)
                return NotFound();

            return Ok(rols);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRolById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var candidate = await Mediator.Send(new GetRolByIdQuery { Id = id });

            if (candidate == null)
                return NotFound();

            return Ok(candidate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdateRol([FromBody] RolModelJson body, [FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            body.Id = id;
            var response = await Mediator.Send(new UpdateRolCommand { Rol = _mapper.Map<Rol>(body) });

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpPost()]
        public async Task<IActionResult> PostCreateRol([FromBody] RolModelJson body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var response = await Mediator.Send(new CreateRolCommand { Rol = _mapper.Map<Rol>(body) });

            if (response != null)
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

            var response = await Mediator.Send(new DeleteRolCommand { Ids = body.Ids });

            if (response)
                return Ok(response);

            return BadRequest();
        }

        [Route("rol-option")]
        [HttpPost()]
        public async Task<IActionResult> PostCreateRolOption([FromBody] CreateRolOptionJsonModel body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var response = await Mediator.Send(new CreateRolOptionCommand { IdRol = body.RolId, OptionIds = body.OptionIds });

            if (!response)
                return BadRequest(response);

            return Ok(response);

        }


        [Route("rol-option")]
        [HttpDelete()]
        public async Task<IActionResult> PostDeleteRolOption([FromBody] DeleteRolOptionJsonModel body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            List<RolOption> listRolOp = new List<RolOption>();

            foreach(var rop in body.RolOption)
            {
                listRolOp.Add(new RolOption
                {
                    OptionId = rop.OptionId,
                    RolId = rop.RolId
                });
            };

            var response = await Mediator.Send(new DeleteRolOptionCommand { rolOptions = listRolOp });

            if (!response)
                return BadRequest(response);

            return Ok(response);

        }

    }
}
