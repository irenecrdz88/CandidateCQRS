using Application.Contracts.Persistence;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    public class CandidateRepository : RepositoryBase<Candidate>, ICandidateRepository
    {
        public CandidateRepository(CandidateDbContext context) : base(context)
        {
        }

        async Task<List<Candidate>> ICandidateRepository.GetCandidatesListQuery(string surname)
        {
            return await _context.Candidates!.Where(c => c.Surname == surname).ToListAsync();
        }
    }
}
