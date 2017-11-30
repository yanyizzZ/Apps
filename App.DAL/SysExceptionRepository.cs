using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;
using App.IDAL;

namespace App.DAL
{
   public class SysExceptionRepository:ISysExceptionRepository,IDisposable
    {
        public int Create(SysException entity)
        {
            using (DB db=new DB())
            {
                db.SysException.Add(entity);
                return db.SaveChanges();
            }
        }

        public IQueryable<SysException> GetList(DB db)
        {
            IQueryable<SysException> list = db.SysException.AsQueryable();
            return list;
        }

        public SysException GetById(string id)
        {
            using (DB db=new DB())
            {
                return db.SysException.SingleOrDefault(a => a.Id == id);
            }
        }

        public void Dispose()
        {
           
        }
    }
}
