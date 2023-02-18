using Application.Contracts.Persistence;
using Application.Features.Candidates.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.CandidateExperiences.Queries
{
    public class GetExperienceByIdHandler : IRequestHandler<GetExperienceById, CandidateExperiencesVm>
    {
        private readonly ICandidateExperienceRepository _experienceRepository;
        private readonly IMapper _mapper;
        public GetExperienceByIdHandler(ICandidateExperienceRepository repository, IMapper mapper)
        {
            _experienceRepository = repository;
            _mapper = mapper;
        }
        public async Task<CandidateExperiencesVm> Handle(GetExperienceById request, CancellationToken cancellationToken)
        {
            return _mapper.Map<CandidateExperiencesVm>(await _experienceRepository.GetExperienceById(request._Id));
        }
    }
}
