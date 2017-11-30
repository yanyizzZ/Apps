using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;
using App.Common;

namespace App.IBLL
{
    public interface ISysExceptionBLL
    {
        List<SysException> GetList(ref GridPager pager, string queryStr);
        SysException GetById(string id);
    }
}
