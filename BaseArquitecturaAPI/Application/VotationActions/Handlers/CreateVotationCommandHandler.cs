using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.VotationActions.Commands;
using Application.VotationActions.Dtos;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.VotationActions.Handlers
{
    public class CreateVotationCommandHandler : IRequestHandler<CreateVotationCommand, bool>
    {
        private readonly IVotationService _votationSevice;
        private readonly ICatalogService _catalogService;
        private readonly IMapper _mapper;
        public CreateVotationCommandHandler(IVotationService votationSevice, ICatalogService catalogService, IMapper mapper)
        {
            _votationSevice = votationSevice;
            _catalogService = catalogService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateVotationCommand request, CancellationToken cancellationToken)
        {
            bool saved = false;

            var city = await _catalogService.GetCityById(request.Votation.CityId);

            if (city == null)
                throw new ErrorException("06", "Código de ciudad no válido");

            // si la votacion a crear es de tipo presidencial, se valida que haya alguna votacion en curso
            if (request.Votation.VotationTypeId == 2)
            {
                var currentVotation = _votationSevice.GetCurrentVotation();

                if (currentVotation != null)
                    throw new ErrorException("05", "Ya hay una votación en curso");

                // validamos que la ciudad sea la indicada para las presidenciales
                if (!city.CityCode.Equals("0"))
                    throw new ErrorException("07", "Código de ciudad incorrecto para elecciones presidenciales");

                saved = await _votationSevice.CreateVotation(request.Votation);

                if (!saved)
                    throw new ErrorException("01", "No se pudo crear la votación");

                // si la votacion es municipal, validar que no se puedan crear varias votaciones en los mismos municipios
            }
            else if (request.Votation.VotationTypeId == 1)
            {
                var currentCityVotation = _votationSevice.GetCurrentVotationByCityId(city.CityId);

                if (currentCityVotation != null)
                    throw new ErrorException("08", "Ya hay una votación en este municipio en curso");

                //validamos que haya una votacion presedencial en curso (id harcoded momentaneamente)

                var varPresidencialVotation = _votationSevice.GetCurrentVotationByCityId(134);

                if (varPresidencialVotation != null)
                    throw new ErrorException("10", "Ya hay una votación presidencial en curso");

                saved = await _votationSevice.CreateVotation(request.Votation);

                if (!saved)
                    throw new ErrorException("01", "No se pudo crear la votación");

            }
            else 
            {
                throw new ErrorException("09", "Código de tipo de votación no válido");
            }

            return saved;
        }
    }
}
