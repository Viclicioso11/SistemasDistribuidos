using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.VotationActions.Commands;
using Application.VotationActions.Dtos;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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
            int votatonId = 0;
            bool saved = false;

            var city = await _catalogService.GetCityById(request.Votation.CityId);

            if (city == null)
                throw new ErrorException("06", "Código de ciudad no válido");

            foreach (var candidateId in request.Candidates)
                if (request.Candidates.Where(c => c == candidateId).Count() > 1)
                    throw new ErrorException("11", "Candidatos repetidos");

            // si la votacion a crear es de tipo presidencial, se valida que haya alguna votacion en curso
            if (request.Votation.VotationTypeId == 2)
            {
                var currentVotation = await _votationSevice.GetCurrentVotation();

                if (currentVotation != null)
                    throw new ErrorException("05", "Ya hay una votación en curso");

                // validamos que la ciudad sea la indicada para las presidenciales
                if (!city.CityCode.Equals("0"))
                    throw new ErrorException("07", "Código de ciudad incorrecto para elecciones presidenciales");

                // obtiene Id de la votacion al guardar
                votatonId = await _votationSevice.CreateVotation(request.Votation);

                if (votatonId == 0)
                    throw new ErrorException("01", "No se pudo crear la votación");

                // a guardar en el detalle de la votacion y el candidato

                saved = await _votationSevice.AddVotationCandidate(request.Candidates, votatonId);

                if (!saved)
                    throw new ErrorException("01", "No se crearon los registros de votación");

                // si la votacion es municipal, validar que no se puedan crear varias votaciones en los mismos municipios
            }
            else if (request.Votation.VotationTypeId == 1)
            {
                var currentCityVotation = await _votationSevice.GetCurrentVotationByCityId(city.CityId);

                if (currentCityVotation != null)
                    throw new ErrorException("08", "Ya hay una votación en este municipio en curso");

                //validamos que haya una votacion presedencial en curso (id harcoded momentaneamente)

                var varPresidencialVotation = await _votationSevice.GetCurrentVotationByCityId(134);

                if (varPresidencialVotation != null)
                    throw new ErrorException("10", "Ya hay una votación presidencial en curso");

                // obtiene Id de la votacion al guardar
                votatonId = await _votationSevice.CreateVotation(request.Votation);

                if (votatonId == 0)
                    throw new ErrorException("01", "No se pudo crear la votación");

                // a guardar en el detalle de la votacion y el candidato

                saved = await _votationSevice.AddVotationCandidate(request.Candidates, votatonId);

                if (!saved)
                    throw new ErrorException("01", "No se crearon los registros de votación");

            }
            else
            {
                throw new ErrorException("09", "Código de tipo de votación no válido");
            }

            return saved;
        }
    }
}
