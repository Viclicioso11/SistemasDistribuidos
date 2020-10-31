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

            body.UserId = id;
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

            var response = await Mediator.Send(new CreateUserCommand { User = _mapper.Map<User>(body) });

            if(response !=null)
                return Ok(response);

            return BadRequest();
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserModelJson body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await Mediator.Send(new DeleteUserCommand { Ids = body.Ids });

            if (response)
                return Ok(response);

            return BadRequest();
        }

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

        [Route("/answerTfa")]
        [HttpPost()]
        public async Task<IActionResult> AnswerTwoFactorAuthentication([FromBody] DeleteUserModelJson body)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await Mediator.Send(new DeleteUserCommand { Ids = body.Ids });

            if (response)
                return Ok(response);
            
            return BadRequest();
            */
            throw new NotImplementedException();
        }
    }
}
