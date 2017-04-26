using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TekinroadsPortal.Models;

namespace TekinroadsPortal.Controllers.Admin
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult BasicTable()
        {
            return View();
        }
        public ActionResult Icons()
        {
            return View();
        }
        public ActionResult GoogleMap()
        {
            return View();
        }
        public ActionResult BlankPage()
        {
            return View();
        }
        public ActionResult AdminSideMenu(){
            /*
            List<AdminMenuItem> list = new List<AdminMenuItem>();
            list.Add(new AdminMenuItem { Link = "/Admin/Dashboard", LinkName = "Dashboard" });
            list.Add(new AdminMenuItem { Link = "/Admin/Profile", LinkName = "Profile" });
            list.Add(new AdminMenuItem { Link = "/Admin/BasicTable", LinkName = "Basic Table" });
            list.Add(new AdminMenuItem { Link = "/Admin/Icons", LinkName = "Icons" });
            list.Add(new AdminMenuItem { Link = "/Admin/GoogleMap", LinkName = "Google Map" });
            list.Add(new AdminMenuItem { Link = "/Admin/BlankPage", LinkName = "Blank Page" });

            return PartialView("AdminSideMenu",list);
            */
            return PartialView("AdminSideMenu");
        }
    }
}