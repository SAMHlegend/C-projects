﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
namespace Accounting.data.Services
{
    public class GenericRepositorie<TEntity> where TEntity:class
    {
        private Accounting_DBEntities _db;
        private DbSet<TEntity> _dbSet;

        public GenericRepositorie(Accounting_DBEntities db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity,bool>> where = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if(where != null)
            {
                query = query.Where(where);
            }
            return query.ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual TEntity GetByID(object Id)
        {
            return _dbSet.Find(Id);
        }


        public virtual void Update(TEntity entity)
        {
           // if (_db.Entry(entity).State == EntityState.Deleted)
            //{
            _dbSet.Attach(entity);
            //}
            _db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            if (_db.Entry(entity).State == EntityState.Deleted)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

            public virtual void Delete(object Id)
        {
            var entity = GetByID(Id);
            Delete(entity);
        }
    }
}
