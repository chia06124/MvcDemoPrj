using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDemoPrj.Models.Interface;
using System.Data.Entity;
using System.Linq.Expressions;

namespace MvcDemoPrj.Models.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected FirstModel db
        {
            get;
            private set;
        }
        public GenericRepository()
        {
            this.db = new FirstModel();
        }
        public void Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                db.Set<TEntity>().Add(entity);
                SaveChange();
                
            }
        }
        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                db.Entry(entity).State = EntityState.Modified;
                SaveChange();
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                db.Entry(entity).State = EntityState.Deleted;
                SaveChange();
            }
        }

        public TEntity Get(decimal SeqID)
        {
            return db.Set<TEntity>().Find(SeqID);
        }
        public IQueryable<TEntity> GetAll()
        {
            return db.Set<TEntity>().AsQueryable();
        }


        public void SaveChange()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
    }
}