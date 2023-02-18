using Application.Contracts.Persistence;
using Application.Features.CandidateExperiences.Commands.Update;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.CandidateExperiences.Commands.Create
{
    public class UpdateCandidateExperienceCommandHandler : IRequestHandler<UpdateCandidateExperienceCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCandidateExperienceCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateCandidateExperienceCommand request, CancellationToken cancellationToken)
        {
            var experience = _mapper.Map<CandidateExperience>(request);
            _unitOfWork.Repository<CandidateExperience>().UpdateEntity(experience);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo pudo modificar la experiencia");
            }

            return experience.Id;
        }
    }
}
