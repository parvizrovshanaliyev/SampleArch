using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SampleArch.Model.BaseEntities.Abstracts;
using SampleArch.Repository.Interfaces;

namespace SampleArch.Repository.Abstracts
{
    public  class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        protected DbContext Context;
        protected readonly DbSet<T> DbSet;

        protected GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {

            return DbSet.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IEnumerable<T> query = DbSet.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual EntityEntry<T> Add(T entity)
        {
            return DbSet.Add(entity);
        }

        public virtual EntityEntry<T> Delete(T entity)
        {
            return DbSet.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}
