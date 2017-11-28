using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.IBLL;
using App.Models;
using Unity.Attributes;
using App.Models.Sys;
namespace App.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [Dependency]
        public IHomeBLL homeBLL { get; set; }
        public ActionResult Index()
        {
            AccountModel account = new AccountModel();
            account.Id = "admin";
            account.TrueName = "admin";
            Session["Account"] = account;
            return View();
        }
        public JsonResult GetTree(string id)
        {
            List<SysModule> menus = homeBLL.GetMenuByPersonId(id);
            var jsonData=(
                from m in menus
                select new {
                     id = m.Id,
                            text = m.Name,
                            value = m.Url,
                            showcheck = false,
                            complete = false,
                            isexpand = false,
                            checkstate = 0,
                            hasChildren = m.IsLast ? false : true,
                            Icon = m.Iconic
                }
                ).ToList();

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}
