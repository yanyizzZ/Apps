using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.IDAL;
using App.Models;
using System.Data.Entity;
namespace App.DAL
{
    public class SysSampleRepository : ISysSampleRepository,IDisposable
    {
        /// <summary>
        /// 获取列表
        ///</summary>
        /// <param name="db">数据库上下文</param>
        /// <returns>数据列表</returns>
        public IQueryable<App.Models.SysSample> GetList(App.Models.DB db)
        {
            IQueryable<SysSample> list = db.SysSample.AsQueryable();
            return list;
        }

        public int Create(App.Models.SysSample entity)
        {
            using (DB db = new DB())
            {
                db.Set<SysSample>().Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DB db = new DB())
            {
                SysSample entity = db.SysSample.SingleOrDefault(a => a.Id == id);
                db.Set<SysSample>().Remove(entity);
                return db.SaveChanges();
            }
        }

        public int Edit(App.Models.SysSample entity)
        {
            using (DB db=new DB())
            {
                db.Set<SysSample>().Attach(entity);
                db.Entry<SysSample>(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public App.Models.SysSample GetById(string id)
        {
            using (DB db=new DB())
            {
                return db.SysSample.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (DB db=new DB())
            {
                SysSample entity = GetById(id);
                if (entity!=null)
                    return true;
                return false;
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
