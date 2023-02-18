using Application.Contracts.Persistence;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    public class CandidateExperienceRepository : RepositoryBase<CandidateExperience>, ICandidateExperienceRepository
    {
        public CandidateExperienceRepository(CandidateDbContext context) : base(context)
        {
            
        }

        public async Task<CandidateExperience> GetExperienceById(int id)
        {
            return await _context.CandidateExperiences!.Where(c => c.Id == id).FirstAsync();
        }

        async Task<List<CandidateExperience>> ICandidateExperienceRepository.GetCandidateExperiences(int id)
        {
            return await _context.CandidateExperiences!.Where(c => c.IdCandidate == id).ToListAsync();
        }

    }
}
