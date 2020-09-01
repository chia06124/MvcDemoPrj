using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemoPrj.SQLModel.Interface
{
   public interface IRepository<TEntity>: IDisposable
        where TEntity:class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(decimal Seq);
        IQueryable<TEntity> GetAll();
        //decimal GetMaxSeq();
        void SaveChange();
    }
}
