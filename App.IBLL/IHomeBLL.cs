using System.Collections.Generic;
using App.Models;
namespace App.IBLL
{
   public interface IHomeBLL
    {
       List<SysModule> GetMenuByPersonId(string moduleId);
    }
}
