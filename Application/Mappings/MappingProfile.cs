using Domain;
using AutoMapper;
using Application.Features.Candidates.Queries;
using Application.Features.Candidates.Commands.CreateCandidate;
using Application.Features.CandidateExperiences;
using Application.Features.CandidateExperiences.Commands.Create;
using Application.Features.Candidates.Commands.UpdateCandidate;
using Application.Features.CandidateExperiences.Commands.Update;

namespace Application.Mappings
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidate, CandidatesVm>();
            CreateMap<CandidateExperience, CandidateExperiencesVm>();
            CreateMap<CreateCandidateCommand, Candidate>();
            CreateMap<UpdateCandidateCommand, Candidate>();
            CreateMap<CreateCandidateExperienceCommand, CandidateExperience>();
            CreateMap<UpdateCandidateExperienceCommand, CandidateExperience>();
        }
    }
}