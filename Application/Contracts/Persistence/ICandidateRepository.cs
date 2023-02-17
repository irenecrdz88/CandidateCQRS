using Domain;

namespace Application.Contracts.Persistence
{
    public interface ICandidateRepository : IAsyncRepository<Candidate>
    {
        Task<List<Candidate>> GetCandidatesListQuery(string surname);
    }
}
