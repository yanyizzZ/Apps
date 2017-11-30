using App.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.IDAL;
using App.Models;
using Unity.Attributes;
using App.Common;

namespace App.BLL
{
    public class SysExceptionBLL : ISysExceptionBLL, IDisposable
    {
        [Dependency]
        public ISysExceptionRepository exceptionRepository { get; set; }
        public List<Models.SysException> GetList(ref GridPager pager, string queryStr)
        {
            DB db = new DB();
            List<SysException> query = null;
            IQueryable<SysException> list = exceptionRepository.GetList(db);
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                list = list.Where(a => a.Message.Contains(queryStr));
                pager.totalRows = list.Count();
            }
            else
                pager.totalRows = list.Count();
            if (pager.order == "desc")
            {
                query = list.OrderByDescending(a
                    => a.CreateTime).Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToList();
            }
            else
                query = list.OrderBy(a
                    => a.CreateTime).Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToList();
            return query;
        }

        public Models.SysException GetById(string id)
        {
            return exceptionRepository.GetById(id);
        }

        public void Dispose()
        {

        }
    }
}
