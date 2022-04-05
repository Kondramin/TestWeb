using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestWeb.Interfaces.Entities;
using TestWeb.Interfaces.Repositories;

namespace TestWeb.Domain.Repository.Base
{
    public class DbRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _Set;

        public DbRepository(AppDbContext context)
        {
            _context = context;
            _Set = context.Set<T>();
        }

        public bool AutoSaveChanges { get; set; } = true;

        public T Add(T entity)
        {
            if(entity == null) throw new ArgumentNullException(nameof(entity));

            _context.Entry(entity).State = EntityState.Added;
            if(AutoSaveChanges) SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity, CancellationToken Cancel = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = EntityState.Added;
            if (AutoSaveChanges) await SaveChangesAsync(Cancel);

            return entity;
        }

        public T Remove(Guid id)
        {
            var entity = _Set.Find(new object[] { id });
            _context.Entry(entity).State = EntityState.Deleted;
            if (AutoSaveChanges) SaveChanges();

            return entity;
        }

        public async Task<T> RemoveAsync(Guid id, CancellationToken Cancel = default)
        {
            var entity = await _Set.FindAsync(new object[] { id }, Cancel).ConfigureAwait(false);
            _context.Entry(entity).State = EntityState.Deleted;
            if (AutoSaveChanges) await SaveChangesAsync(Cancel).ConfigureAwait(false);

            return entity;
        }

        public bool ExistById(Guid id) => GetAll().Any(x => x.Id == id);
        
        public async Task<bool> ExistByIdAsync(Guid id, CancellationToken Cancel = default) => await GetAll().AnyAsync(x => x.Id == id, Cancel).ConfigureAwait(false);

        public IQueryable<T> GetAll() => _Set;
        
        public T GetById(Guid id) => GetAll().FirstOrDefault(x => x.Id == id);

        public async Task<T> GetByIdAsync(Guid id, CancellationToken Cancel = default) => await GetAll().FirstOrDefaultAsync(x => x.Id == id, Cancel).ConfigureAwait(false);

        public int SaveChanges() => _context.SaveChanges();

        public async Task<int> SaveChangesAsync(CancellationToken Cancel = default) => await _context.SaveChangesAsync(Cancel).ConfigureAwait(false);

        public T Update(T entity)
        {
            if(!ExistById(entity.Id)) throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = EntityState.Modified;
            if (AutoSaveChanges) SaveChanges();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken Cancel = default)
        {
            if(!await ExistByIdAsync(entity.Id, Cancel).ConfigureAwait(false)) throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = EntityState.Modified;
            if (AutoSaveChanges) await SaveChangesAsync(Cancel).ConfigureAwait(false);

            return entity;
        }
    }
}
