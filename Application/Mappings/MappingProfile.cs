using Domain;
using AutoMapper;
using Application.Features.Candidates.Queries;
using System.IO;
using Application.Features.Candidates.Commands.CreateCandidate;
using Application.Features.Candidates.Commands.UpdateCandidate;

namespace Application.Mappings
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidate, CandidatesVm>();
            CreateMap<CreateCandidateCommand, Candidate>();
            CreateMap<UpdateCandidateCommand, Candidate>();
        }
    }
}