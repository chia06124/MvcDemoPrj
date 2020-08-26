using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDemoPrj.Models.Interface;
using System.Data.Entity;

namespace MvcDemoPrj.Models.Repository
{
    public class SI_StocksReportRepository: ISI_StocksReportRepository
    {
        protected FirstModel db
        {
            get;
            private set;
        }
        public SI_StocksReportRepository()
        {
            this.db = new FirstModel();
        }
        public void Create(SI_StocksReport instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.SI_StocksReport.Add(instance);
                this.SaveChanges();
            }
        }
        public void Update(SI_StocksReport instance)
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
        public void Delete(SI_StocksReport instance)
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
        public SI_StocksReport Get(decimal SeqID)
        {
            
            return db.SI_StocksReport.Find(SeqID);
        }

        //public IQueryable<SI_ResearcherVisit> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

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