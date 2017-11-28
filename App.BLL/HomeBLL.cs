using App.IBLL;
using System;
using System.Collections.Generic;
using Unity.Attributes;
using App.IDAL;
namespace App.BLL
{
    public class HomeBLL : IHomeBLL
    {
        [Dependency]
        public IHomeRepository HomeRepository { get; set; }
        public List<Models.SysModule> GetMenuByPersonId(string moduleId)
        {
            return HomeRepository.GetMenuByPersonId(moduleId);
        }
    }
}
