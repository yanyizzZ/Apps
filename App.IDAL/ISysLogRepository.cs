using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;

namespace App.IDAL
{
   public  interface ISysLogRepository
    {
       int Create(SysLog entity);
       void Delete(DB db, string[] deleteCollection);
       IQueryable<SysLog> GetList(DB db);
       SysLog GetById(string id);
    }
}
