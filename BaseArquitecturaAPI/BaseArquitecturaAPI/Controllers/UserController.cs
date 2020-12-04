using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.UserActions.Commands;
using Application.UserActions.Querys;
using Application.UserRolActions.Commands;
using AutoMapper;
using BaseArquitecturaAPI.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseArquitecturaAPI.Controllers
{
    [Route("api/user/")]
    public class UserController : BaseController
    {

        private readonly IMapper _mapper;
        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllUsers(int page =1 , string filter = "", int records = 10)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var users = await Mediator.Send(new GetAllUsersQuery { ActualPage = page, FilterBy = filter, RecordsByPage = records });

            if (users == null)
                return NotFound();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var user = await Mediator.Send(new GetUserByIdQuery { Id = id });

            if (user == null)
                return NotFound();

            return Ok(user) ;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdateUser([FromBody] UserModelJson body, [FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            body.Id = id;
            var response = await Mediator.Send(new UpdateUserCommand { User = _mapper.Map<User>(body) });

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpPost()]
        public async Task<IActionResult> PostCreateUser([FromBody] UserModelJson body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var response = await Mediator.Send(new CreateUserCommand { User = _mapper.Map<User>(body), RolId = body.RolId });

            if(response !=null)
                return Ok(response);

            return BadRequest();
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteModelJson body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var response = await Mediator.Send(new DeleteUserCommand { Ids = body.Ids });

            if (response)
                return Ok(response);

            return BadRequest();
        }

        // Auth and TFA
        [Route("auth")]
        [HttpPost()]
        public async Task<IActionResult> Authenticate([FromBody] LoginModelJson body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await Mediator.Send(new AuthenticationCommand { Email = body.Email, Password = body.Password });

            if (response == null)
                return BadRequest(response);
            
            return Ok(response);
           
        }

        [Route("answerTfa")]
        [HttpPost()]
        public async Task<IActionResult> AnswerTwoFactorAuthentication([FromBody] AnswerTwoFactorAuthenticationModelJson body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await Mediator.Send(new AnswerTwoFactorAuthenticatonCommand { UserId = body.UserId, AuthenticationId = body.Id, OneTimePassword = body.OneTimePassword });

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        // UserRols
        [Route("user-rol")]
        [HttpPost()]
        public async Task<IActionResult> PostCreateRolOption([FromBody] CreateUserRolJsonModel body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var response = await Mediator.Send(new CreateUserRolCommand { IdUser = body.UserId, RolIds = body.RolIds });

            if (!response)
                return BadRequest(response);

            return Ok(response);

        }


        [Route("user-rol")]
        [HttpDelete()]
        public async Task<IActionResult> PostDeleteRolOption([FromBody] DeleteUserRolJsonModel body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = HttpContext.Items["UserId"] == null ? "0" : HttpContext.Items["UserId"].ToString();

            if (userId.Equals("0"))
                throw new UnauthorizedException("Usuario no autorizado");

            var response = await Mediator.Send(new DeleteUserRolCommand { UserId = body.UserId, RolId = body.RolId });

            if (!response)
                return BadRequest(response);

            return Ok(response);

        }
    }
}
