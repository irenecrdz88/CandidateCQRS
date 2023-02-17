using MediatR;

namespace Application.Features.Candidates.Queries
{
    public class GetCandidates : IRequest<IEnumerable<CandidatesVm>>
    {

        public GetCandidates()
        {
        }
    }
}
