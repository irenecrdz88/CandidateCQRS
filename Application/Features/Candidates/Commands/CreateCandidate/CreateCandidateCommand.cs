using Application.Features.Candidates.Queries;
using MediatR;

namespace Application.Features.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public CreateCandidateCommand(CandidatesVm cand)
        {
            Name = cand.Name;
            Surname = cand.Surname;
            Email = cand.Email;
            BirthDate = cand.BirthDate;
        }
    }
}
