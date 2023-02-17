using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Candidates.Queries
{
    public class GetCandidatesHandler : IRequestHandler<GetCandidates, IEnumerable<CandidatesVm>>
    {

        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public GetCandidatesHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CandidatesVm>> Handle(GetCandidates request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<CandidatesVm>>(await _candidateRepository.GetAllAsync());
        }
    }
}
