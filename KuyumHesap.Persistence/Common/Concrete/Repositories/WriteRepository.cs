using KuyumHesap.Application.Common.Abstractions.Repositories;
using KuyumHesap.Domain.Command;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Persistence.Common.Concrete.Repositories
{

    public class WriteRepository<T> : IWriteRepository<T> where T : class, IBaseEntity, new()
    {
        private readonly DbContext dbContext;

        public WriteRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            var tab = await Table.AddAsync(entity);
            return tab.Entity;
        }



        public async Task AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }
        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task HardDeleteRangeAsync(IList<T> entity)
        {
            await Task.Run(() => Table.RemoveRange(entity));
        }

        public async Task SoftDeleteAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
        }

        public async Task<T> DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }
    }
}
