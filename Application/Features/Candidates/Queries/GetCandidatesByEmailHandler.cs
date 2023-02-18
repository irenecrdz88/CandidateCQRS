using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Candidates.Queries
{
    public class GetCandidatesByEmailHandler : IRequestHandler<GetCandidatesByEmail, List<CandidatesVm>>
    {

        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public GetCandidatesByEmailHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<List<CandidatesVm>> Handle(GetCandidatesByEmail request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<CandidatesVm>>(await _candidateRepository.GetCandidatesByEmail(request._Email));
        }
    }
}
