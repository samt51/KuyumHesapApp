using KuyumHesap.Application.Common.Abstractions.Repositories;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Persistence.Common.Concrete.Repositories;
using KuyumHesap.Persistence.Common.Context;

namespace KuyumHesap.Persistence.Common.Concrete.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (dbContext.Database.CurrentTransaction == null) return;
            await dbContext.Database.CommitTransactionAsync(cancellationToken);
        }

        public async Task RollBackAsync(CancellationToken cancellationToken = default)
        {
            if (dbContext.Database.CurrentTransaction == null) return;
            await dbContext.Database.RollbackTransactionAsync(cancellationToken);
        }

        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();

        public async Task OpenTransactionAsync(CancellationToken cancellationToken)
        {
            if (dbContext.Database.CurrentTransaction != null)
                return;

            await dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {

            try
            {
                var result = await dbContext.SaveChangesAsync(cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                await RollBackAsync(cancellationToken);
                throw new Exception(ex.Message);

            }
        }
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);

    }
}
