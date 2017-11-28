using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using App.BLL;
using App.DAL;
using App.IBLL;
using App.IDAL;
using Unity;

namespace App.Core
{
    public class DependencyRegisterType
    {
        //系统注入
        public static void Container_Sys(ref UnityContainer container)
        {
            container.RegisterType<ISysSampleBLL, SysSampleBLL>();
            container.RegisterType<ISysSampleRepository, SysSampleRepository>();
            //菜单
            container.RegisterType<IHomeBLL, HomeBLL>();
            container.RegisterType<IHomeRepository, HomeRepository>();
            //日志
            container.RegisterType<IHomeBLL, HomeBLL>();
            container.RegisterType<IHomeRepository, HomeRepository>();
        }
    }
}
