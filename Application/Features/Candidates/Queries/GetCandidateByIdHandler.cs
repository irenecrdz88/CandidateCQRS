using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Candidates.Queries
{
    public class GetCandidateByIdHandler : IRequestHandler<GetCandidateById, CandidatesVm>
    {

        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public GetCandidateByIdHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<CandidatesVm> Handle(GetCandidateById request, CancellationToken cancellationToken)
        {
            return _mapper.Map<CandidatesVm>(await _candidateRepository.GetCandidateById(request._Id));
        }
    }
}
