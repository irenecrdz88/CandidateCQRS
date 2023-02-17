using Domain;

namespace Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository CandidateRepository { get;  }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
