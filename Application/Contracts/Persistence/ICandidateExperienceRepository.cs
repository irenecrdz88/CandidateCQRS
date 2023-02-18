using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface ICandidateExperienceRepository : IAsyncRepository<CandidateExperience>
    {
        Task<List<CandidateExperience>> GetCandidateExperiences(int id);
        Task<CandidateExperience> GetExperienceById(int id);
    }
}
