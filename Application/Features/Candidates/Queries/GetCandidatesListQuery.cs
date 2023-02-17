using MediatR;

namespace Application.Features.Candidates.Queries
{
    public class GetCandidatesListQuery : IRequest<List<CandidatesVm>>
    {
        public string _Surname { get; set; }

        public GetCandidatesListQuery(string surname)
        {
            _Surname = surname ?? throw new ArgumentNullException(nameof(surname));
        }
    }
}
