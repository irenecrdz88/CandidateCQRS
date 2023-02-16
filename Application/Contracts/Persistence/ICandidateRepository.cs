using Domain;

namespace Application.Contracts.Persistence
{
    public interface ICandidateRepository : IAsyncRepository<Candidate>
    {
        Task<Candidate> GetCandidateByEmail(string email);
    }
}
