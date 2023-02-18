using MediatR;

namespace Application.Features.Candidates.Queries
{
    public class GetCandidatesBySurname : IRequest<List<CandidatesVm>>
    {
        public string _Surname { get; set; }

        public GetCandidatesBySurname(string surname)
        {
            _Surname = surname ?? throw new ArgumentNullException(nameof(surname));
        }
    }
}
