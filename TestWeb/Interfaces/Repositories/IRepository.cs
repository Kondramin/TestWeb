using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestWeb.Interfaces.Entities;

namespace TestWeb.Interfaces.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        bool AutoSaveChanges { get; set; }

        IQueryable<T> GetAll();
        
        bool ExistById(Guid id);
        Task<bool> ExistByIdAsync(Guid id, CancellationToken Cancel = default);

        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id, CancellationToken Cancel = default);

        T Add(T entity);
        Task<T> AddAsync(T entity, CancellationToken Cancel = default);

        T Update(T entity);
        Task<T> UpdateAsync(T entity, CancellationToken Cancel = default);

        T Remove(Guid id);
        Task<T> RemoveAsync(Guid id, CancellationToken Cancel = default);

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken Cancel = default);

    }
}
