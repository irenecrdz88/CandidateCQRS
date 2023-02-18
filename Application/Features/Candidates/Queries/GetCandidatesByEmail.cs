using MediatR;

namespace Application.Features.Candidates.Queries
{
    public class GetCandidatesByEmail : IRequest<List<CandidatesVm>>
    {
        public string _Email { get; set; }

        public GetCandidatesByEmail(string email)
        {
            _Email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
