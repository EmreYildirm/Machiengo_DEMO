using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Machinego_Demo.DataAccesLayer.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        public TEntity Add(TEntity entity);
        public TEntity SingleOrDefault(int id);
        public IQueryable<TEntity> List();
        public IQueryable<TEntity> List(Expression<Func<TEntity, bool>> expression);
        public void BeginTransaction();
        public void Rollback();
        public void Commit();
    }
}
