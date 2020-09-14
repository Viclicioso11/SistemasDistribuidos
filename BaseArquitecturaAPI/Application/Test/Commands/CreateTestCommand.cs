using Application.Test.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Test.Commands
{
    public class CreateTestCommand : IRequest<TestDto>
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }
    }
}
