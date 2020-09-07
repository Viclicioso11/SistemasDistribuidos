using Application.Test.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Test.Querys
{
    public class GetTestByIdQuery : IRequest<TestDto>
    {
        public int TestId { get; set; }
    }
}
