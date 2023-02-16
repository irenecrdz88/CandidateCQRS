using Domain;
using AutoMapper;
using Application.Features.Candidates.Queries;

namespace Application.Mappings
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidate, CandidatesVm>();
        }
    }
}
