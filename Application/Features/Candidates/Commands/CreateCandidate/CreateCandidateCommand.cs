using MediatR;

namespace Application.Features.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
