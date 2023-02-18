using Application.Features.Candidates.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CandidateExperiences.Queries
{
    public class GetCandidateExperiences : IRequest<CandidateExperiencesVm>
    {
        public int _Id { get; set; }

        public GetCandidateExperiences(int id)
        {
            _Id = id;
        }
    }
}
