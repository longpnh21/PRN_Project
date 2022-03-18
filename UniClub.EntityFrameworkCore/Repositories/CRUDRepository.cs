using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Interfaces;
using UniClub.Repositories.Interfaces;
using UniClub.Specifications;
using UniClub.Specifications.Interfaces;

namespace UniClub.EntityFrameworkCore.Repositories
{
    public abstract class CRUDRepository<T> : ICRUDRepository<T> where T : BaseEntity
    {
        private readonly IApplicationDbContext _context;
        protected abstract DbSet<T> DbSet { get; }

        public CRUDRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> GetByIdAsync(CancellationToken cancellationToken, ISpecification<T> specification)
        => await SpecificationEvaluator<T>.GetQuery(DbSet, specification).FirstOrDefaultAsync();

        public virtual async Task<(List<T> Items, int Count)> GetListAsync(CancellationToken cancellationToken, ISpecification<T> specification = null)
        {
            List<T> result = new();
            int count = 0;
            try
            {
                var query = SpecificationEvaluator<T>.GetQuery(DbSet, specification);
                count = await query.CountAsync(cancellationToken);
                if (specification.IsPagination)
                {
                    result = await query.Skip(specification.Skip).Take(specification.Take).ToListAsync(cancellationToken);
                }
                else
                {
                    result = await query.ToListAsync(cancellationToken);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return (result, count);
        }

        public virtual async Task<int> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                DbSet.Add(entity);
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<int> UpdateAsync(T entity, T updatedEntity, CancellationToken cancellationToken)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                UpdateEntityWithInDatabase(entity, updatedEntity);
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<int> RecoverAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                entity.IsDeleted = false;

                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<int> DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                DbSet.Remove(entity);
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<int> HardDeleteAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                entity.IsHardDeleted = true;
                DbSet.Remove(entity);
                return await _context.SaveChangesAsync(cancellationToken);

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected virtual void UpdateEntityWithInDatabase(T entity, T updatedEntity)
        {
            foreach (var inDatabaseProperty in entity.GetType().GetProperties())
            {
                if (!inDatabaseProperty.Name.Equals("Id"))
                {
                    var entityValue = updatedEntity.GetType().GetProperty(inDatabaseProperty.Name).GetValue(updatedEntity);
                    {
                        if (entityValue != null && entityValue != default)
                        {
                            updatedEntity.GetType().GetProperty(inDatabaseProperty.Name).SetValue(entity, entityValue);
                        }
                    }
                }
            }
        }
    }
}