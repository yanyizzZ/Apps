using App.IDAL;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace App.DAL
{
    public class HomeRepository : IHomeRepository, IDisposable
    {

       List<SysModule> IHomeRepository.GetMenuByPersonId(string moduleId)
       {
           using (DB db = new DB())
           {
               var menus = (
                   from m in db.SysModule
                   where m.ParentId == moduleId
                   where m.Id != "0"
                   select m
                   ).Distinct().OrderBy(a => a.Sort).ToList();
               return menus;
           }
       }

       public void Dispose()
       {
       }
    }
}
