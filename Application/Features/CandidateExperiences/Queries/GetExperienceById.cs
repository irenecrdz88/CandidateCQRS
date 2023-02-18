using Application.Features.Candidates.Queries;
using MediatR;

namespace Application.Features.CandidateExperiences.Queries
{
    public class GetExperienceById : IRequest<CandidateExperiencesVm>
    {
        public int _Id { get; set; }

        public GetExperienceById(int id)
        {
            _Id = id;
        }
    }
}
