﻿using Hairo.Entities;
using Hairo.Entities.Databases;
using Hario.Contract;
using Hario.Repo.Extenesions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Hario.Repo
{
    public abstract class BaseRepository<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly HairoDbContext RepositoryContext;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(HairoDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
            _dbSet = RepositoryContext.Set<T>();
        }

        public virtual IQueryable<T> FindAll(Expression<Func<T, bool>>? predicate = null)
            => _dbSet.WhereIf(predicate != null, predicate!);

        public virtual async Task<T> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            var item = await RepositoryContext.FindAsync<T>(new object[] { id }, cancellationToken);
            return item;
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
            => RepositoryContext.SaveChangesAsync(cancellationToken);
    }
}
