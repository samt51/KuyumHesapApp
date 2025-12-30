using KuyumHesap.Domain.Command;

namespace KuyumHesap.Application.Common.Abstractions.Repositories
{
    public interface IWriteRepository<T> where T : class, IBaseEntity, new()
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(List<T> entities);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> DeleteAsync(T entity);
        Task HardDeleteRangeAsync(IList<T> entity);
    }
}
