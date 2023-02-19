using MediatR;

namespace Application.Features.Candidates.Queries
{
    public class GetCandidatesBySurnameAndEmail : IRequest<List<CandidatesVm>>
    {
        public string _Email { get; set; }
        public string _Surname { get; set; }

        public GetCandidatesBySurnameAndEmail(string surname, string email)
        {
            _Email = email ?? throw new ArgumentNullException(nameof(email));
            _Surname = surname ?? throw new ArgumentNullException(nameof(surname)); 
        }
    }
}
