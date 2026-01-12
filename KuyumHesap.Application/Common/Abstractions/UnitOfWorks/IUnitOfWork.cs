using KuyumHesap.Application.Common.Abstractions.Repositories;
using KuyumHesap.Domain.Command;

namespace KuyumHesap.Application.Common.Abstractions.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IBaseEntity, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IBaseEntity, new();
        Task OpenTransactionAsync(CancellationToken cancellationToken);
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollBackAsync(CancellationToken cancellationToken = default);
    }
}
