using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.OptionActions.Commands;
using Application.UserActions.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OptionActions.Handlers
{
    public class DeleteOptionCommandHandler : IRequestHandler<DeleteOptionCommand, bool>
    {
        private readonly IOptionService _service;
        public DeleteOptionCommandHandler(IOptionService service)
        {
            _service = service;
            
        }
        public async Task<bool> Handle(DeleteOptionCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.DeleteOptions(request.Ids);

            if (!result)
                throw new ErrorException("03", $"Error tratando de eliminar opciones");

            return result;
        }
    }
}
