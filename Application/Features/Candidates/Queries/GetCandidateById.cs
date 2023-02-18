using MediatR;

namespace Application.Features.Candidates.Queries
{
    public class GetCandidateById : IRequest<CandidatesVm>
    {
        public int _Id { get; set; }

        public GetCandidateById(int id)
        {
            _Id = id;
        }
    }
}
