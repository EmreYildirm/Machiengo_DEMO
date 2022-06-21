using Machinego_Demo.DataAccesLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Machinego_Demo.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        public TEntity Add(TEntity entity);
        public TEntity SingleOrDefault(int id);
        public IQueryable<TEntity> List();
        public IQueryable<TEntity> List(Expression<Func<TEntity, bool>> expression);
    }
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly MachiengoDbContext _context;
        protected MachiengoDbContext context { get { return _context; } }

        private readonly DbSet<TEntity> _dbSet;

        protected BaseService(MachiengoDbContext dbContext)
        {
            _context = dbContext;
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
    }
}
