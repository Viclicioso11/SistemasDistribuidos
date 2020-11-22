﻿using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.OptionActions.Commands;
using Application.RolActions.Commands;
using Application.UserActions.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.RolActions.Handlers
{
    public class DeleteOptionCommandHandler : IRequestHandler<DeleteRolCommand, bool>
    {
        private readonly IRolService _service;
        public DeleteOptionCommandHandler(IRolService service)
        {
            _service = service;
            
        }
        public async Task<bool> Handle(DeleteRolCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.DeleteRols(request.Ids);

            if (!result)
                throw new ErrorException("03", $"Error tratando de eliminar roles");

            return result;
        }
    }
}
