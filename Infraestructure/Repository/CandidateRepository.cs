using Application.Contracts.Persistence;
using Application.Features.Candidates.Queries;
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

        async Task<List<Candidate>> ICandidateRepository.GetCandidatesBySurname(string surname)
        {
            return await _context.Candidates!.Where(c => c.Surname.Contains(surname)).ToListAsync();
        }

        async Task<List<Candidate>> ICandidateRepository.GetCandidatesByEmail(string email)
        {
            return await _context.Candidates!.Where(c => c.Email == email).ToListAsync();
        }

        async Task<Candidate> ICandidateRepository.GetCandidateById(int id) =>  
            _context.Candidates!
                .Where(c => c.Id == id)
                .Include(e => e.CandidateExperiences)
                .FirstOrDefault();

        public async Task<List<Candidate>> GetCandidatesBySurnameAndEmail(string surname, string email)
        {
            return await _context.Candidates!.Where(c => c.Surname.Contains(surname)).Intersect(_context.Candidates!.Where(c => c.Email == email)).ToListAsync();
        }
    }
}
