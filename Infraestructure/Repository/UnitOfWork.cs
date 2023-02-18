using Application.Contracts.Persistence;
using Data;
using Domain;
using System.Collections;

namespace Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly CandidateDbContext _context;

        private ICandidateRepository _candidateRepository;
        private ICandidateExperienceRepository _candidateExperienceRepository;
        

        public ICandidateRepository CandidateRepository => _candidateRepository ??= new CandidateRepository(_context);
        public ICandidateExperienceRepository CandidateExperienceRepository => _candidateExperienceRepository ??= new CandidateExperienceRepository(_context);
      
        public UnitOfWork(CandidateDbContext context)
        {
            _context = context;
        }

        public CandidateDbContext CandidateDbContext => _context;

        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Err");
            }

        }



        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }


    }
}
