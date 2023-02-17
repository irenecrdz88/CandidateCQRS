using MediatR;

namespace Application.Features.Candidates.Commands.UpdateCandidate
{
    public class UpdateCandidateCommand: IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }
    }
}
