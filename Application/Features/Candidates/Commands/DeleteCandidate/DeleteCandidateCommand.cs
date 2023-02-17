using MediatR;

namespace Application.Features.Candidates.Commands.DeleteCandidate
{

    public class DeleteCandidateCommand : IRequest
    {
        public int Id { get; set; }
    }
}
