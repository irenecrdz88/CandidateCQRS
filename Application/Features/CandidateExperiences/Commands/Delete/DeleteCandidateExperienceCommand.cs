using MediatR;

namespace Application.Features.Candidates.Commands.DeleteCandidateExperience
{

    public class DeleteCandidateExperienceCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteCandidateExperienceCommand(int id)
        {
            Id = id;
        }
    }
}
