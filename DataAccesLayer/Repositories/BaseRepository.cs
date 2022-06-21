using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Machinego_Demo.DataAccesLayer.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        private readonly MachiengoDbContext _context;
        protected MachiengoDbContext context { get { return _context; } }

        private readonly DbSet<TEntity> _dbSet;

        private IDbContextTransaction _transaction;

        protected BaseRepository(MachiengoDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;

        }

        public IQueryable<TEntity> List()
        {
            return _dbSet.AsQueryable();
        }
        public IQueryable<TEntity> List(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);

        }

        public TEntity SingleOrDefault(int id)
        {
            return _dbSet.Find(id);
        }
        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
        public void Commit()
        {
            _transaction.Commit();
        }
    }
}
