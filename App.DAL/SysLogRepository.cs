using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;
using App.IDAL;

namespace App.DAL
{
   public class SysLogRepository:ISysLogRepository,IDisposable
    {
        public int Create(SysLog entity)
        {
            using (DB db = new DB())
            {
                db.SysLog.Add(entity);
                return db.SaveChanges();
                    
            }
        }

        public void Delete(DB db, string[] deleteCollection)
        {
            //IQueryable<SysLog> collection = from f in db.SysLog
            //                                where deleteCollection.Contains(f.Id)
            //                                select f;

            var collection = db.SysLog.Where(a => deleteCollection.Contains(a.Id));
            foreach (var item in collection)
            {
                // db.SysLog.DeleteObject(item);
                db.SysLog.Remove(item);
            }
            db.SaveChanges();
        }

        public IQueryable<SysLog> GetList(DB db)
        {
            IQueryable<SysLog> list = db.SysLog.AsQueryable();
            return list;
        }

        public SysLog GetById(string id)
        {
            using (DB db=new DB())
            {
                return db.SysLog.SingleOrDefault(a => a.Id == id);
            }
        }
        public void Dispose()
        {

        }
    }
}
