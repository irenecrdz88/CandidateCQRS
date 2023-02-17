using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Candidates.Queries
{
    public class GetCandidatesListHandler : IRequestHandler<GetCandidatesListQuery, List<CandidatesVm>>
    {

        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public GetCandidatesListHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<List<CandidatesVm>> Handle(GetCandidatesListQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<CandidatesVm>>(await _candidateRepository.GetCandidatesListQuery(request._Surname));
        }
    }
}
