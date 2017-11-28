using App.Models;
using System.Collections.Generic;

namespace App.IDAL
{
    public interface IHomeRepository
    {
        List<SysModule> GetMenuByPersonId(string moduleId);
    }
}
