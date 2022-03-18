using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Repositories.Interfaces;
using UniClub.Specifications;
using UniClub.Specifications.Interfaces;

namespace UniClub.EntityFrameworkCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<Person> _userManager;

        public UserRepository(IApplicationDbContext context, UserManager<Person> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public virtual async Task<Person> GetByIdAsync(CancellationToken cancellationToken, ISpecification<Person> specification)
        => await SpecificationEvaluator<Person>.GetQuery(_context.People, specification).FirstOrDefaultAsync();

        public virtual async Task<(List<Person> Items, int Count)> GetListAsync(CancellationToken cancellationToken, ISpecification<Person> specification = null)
        {
            List<Person> result = new();
            int count = 0;
            try
            {
                var query = SpecificationEvaluator<Person>.GetQuery(_context.People, specification);
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

        public virtual async Task<int> CreateAsync(Person entity, CancellationToken cancellationToken)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                _context.People.Add(entity);
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<int> UpdateAsync(Person entity, Person updatedEntity, CancellationToken cancellationToken)
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

        public virtual async Task<int> DeleteAsync(Person entity, CancellationToken cancellationToken)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                _context.People.Remove(entity);
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<int> HardDeleteAsync(Person entity, CancellationToken cancellationToken)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                entity.IsHardDeleted = true;
                _context.People.Remove(entity);
                return await _context.SaveChangesAsync(cancellationToken);

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected virtual void UpdateEntityWithInDatabase(Person entity, Person updatedEntity)
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
