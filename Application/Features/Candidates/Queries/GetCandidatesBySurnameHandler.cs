using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Candidates.Queries
{
    public class GetCandidatesBySurnameHandler : IRequestHandler<GetCandidatesBySurname, List<CandidatesVm>>
    {

        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public GetCandidatesBySurnameHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<List<CandidatesVm>> Handle(GetCandidatesBySurname request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<CandidatesVm>>(await _candidateRepository.GetCandidatesBySurname(request._Surname));
        }
    }
}
