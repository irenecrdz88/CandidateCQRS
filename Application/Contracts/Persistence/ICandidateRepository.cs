using Domain;

namespace Application.Contracts.Persistence
{
    public interface ICandidateRepository : IAsyncRepository<Candidate>
    {
        Task<List<Candidate>> GetCandidatesBySurname(string surname);
        Task<List<Candidate>> GetCandidatesBySurnameAndEmail(string surname, string email);

        Task<List<Candidate>> GetCandidatesByEmail(string email);
        Task<Candidate> GetCandidateById(int id);
    }
}
