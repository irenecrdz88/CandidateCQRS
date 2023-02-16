using Domain;
using MediatR;

namespace Application.Features.Candidates.Queries
{
    public class GetCandidatesListQuery : IRequest<List<CandidatesVm>>
    {
        public string _Email { get; set; }

        public GetCandidatesListQuery(string email)
        {
            _Email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
