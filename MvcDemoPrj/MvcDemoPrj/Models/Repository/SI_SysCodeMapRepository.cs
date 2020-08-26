using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDemoPrj.Models.Interface;
using System.Data.Entity;
namespace MvcDemoPrj.Models.Repository
{
    public class SI_SysCodeMapRepository : ISI_SysCodeMapRepository
    {
        protected FirstModel db
        {
            get;
            private set;
        }
        public SI_SysCodeMapRepository()
        {
            this.db = new FirstModel();
        }
        public void Create(sysCodeMap instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.sysCodeMap.Add(instance);
                this.SaveChanges();
            }
        }
        public void Update(sysCodeMap instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Modified;
                this.SaveChanges();
            }
        }
        public void Delete(sysCodeMap instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Deleted;
                this.SaveChanges();
            }
        }
        public sysCodeMap Get(decimal SeqID)
        {

            return db.sysCodeMap.Find(SeqID);
        }

        public IQueryable<sysCodeMap> GetAll()
        {
            return db.sysCodeMap.OrderBy(x => x.Seq );
        }

        public void SaveChanges()
        {
            this.db.SaveChanges();
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
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}