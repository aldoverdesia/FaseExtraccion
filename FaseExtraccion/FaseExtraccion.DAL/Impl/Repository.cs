using FaseExtraccion.DAL.DBManager;
using FaseExtracion.Infraestructure.AbstractRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaseExtraccion.DAL.Impl
{
     public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly FaseExtraccionContext _context;
        private DbSet<TEntity> _dbSet;

        protected DbSet<TEntity> DbSet
        {
            get => _dbSet ?? (_dbSet = _context.Set<TEntity>());
        }

        public Repository(FaseExtraccionContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                ArgumentNullException exception = new ArgumentNullException($"{nameof(entity)} entity must not be null");
                throw exception;
            }

            try
            {

                var entityAdded = _context.Add(entity);
                _context.SaveChanges();
                return entityAdded.Entity;
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
                throw exception;
            }
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                return GetQueryable(predicate).Count();
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"Couldn't retrieve Count: {ex.Message}");
                throw exception;
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                ArgumentNullException exception = new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
                throw exception;
            }

            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"{nameof(entity)} could not be deleted: {ex.Message}");
                throw exception;
            }
        }

        public async Task DeleteByPredicateAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = GetQueryable(predicate);
            DbSet.RemoveRange(query.AsNoTracking());
            _context.SaveChanges();

        }

        public virtual IEnumerable<TEntity> GetAllByPredicate(Expression<Func<TEntity, bool>> predicate)
        {

            IQueryable<TEntity> query = GetQueryable(predicate);
            return query.AsEnumerable();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                Expression<Func<TEntity, bool>> defaultPredicate = o => true;
                return DbSet.Where(predicate ?? defaultPredicate);
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"Couldn't retrieve Queryable: {ex.Message}");
                throw exception;
            }
        }


        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                ArgumentNullException exception = new ArgumentNullException($"{nameof(entity)} entity must not be null");
                throw exception;
            }

            try
            {
                var entityUpdated = _context.Update(entity);
                _context.SaveChanges();
                return entityUpdated.Entity;
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
                throw exception;

            }
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {

            Expression<Func<TEntity, bool>> defaultPredicate = o => true;
            return await DbSet.AnyAsync(predicate ?? defaultPredicate);

        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {

            Expression<Func<TEntity, bool>> defaultPredicate = o => true;
            return DbSet.Any(predicate ?? defaultPredicate);

        }
    }
}
