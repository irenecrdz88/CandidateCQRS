using Application.Contracts.Persistence;
using Application.Features.Candidates.Commands.CreateCandidate;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CandidateExperiences.Commands.Create
{
    public class CreateCandidateExperienceCommandHandler : IRequestHandler<CreateCandidateExperienceCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCandidateExperienceCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCandidateExperienceCommand request, CancellationToken cancellationToken)
        {
            var experience = _mapper.Map<CandidateExperience>(request);
            _unitOfWork.Repository<CandidateExperience>().AddEntity(experience);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar la experiencia");
            }

            return experience.Id;
        }
    }
}
