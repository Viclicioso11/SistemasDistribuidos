using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Test.Commands;
using Application.Test.Querys;
using BaseArquitecturaAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseArquitecturaAPI.Controllers
{
    [Route("api/votation")]
    public class VotationController : BaseController
    {

        [HttpGet]
        public IActionResult GetAllTests()
        {
            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestValueById(int id)
        {
            var response = await Mediator.Send(new GetTestByIdQuery { TestId = id});

            return Ok(response);
        }


        [HttpPost()]
        public async Task<IActionResult> PostCreateVotation([FromBody] VotationModelJson body)
        {
            var response = await Mediator.Send(new CreateTestCommand { Descripcion = body.Description, Id = body.Id});

            return Ok(response);
        }

    }
}
