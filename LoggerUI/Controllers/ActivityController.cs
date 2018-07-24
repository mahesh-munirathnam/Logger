using Logger.BAL;
using Logger.DAL.Domain;
using LoggerUI.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoggerPortal.Controllers
{
    [SessionFilter]
    public class ActivityController : Controller
    {
        private UnitOfWork uow = new UnitOfWork(new DBEntities());

        // GET: Activity
        public ActionResult Index()
        {

            var activities = uow.Activities.GetAll().ToList();//.Find(t => t.DateCreated == DateTime.Now).ToList();
            ViewBag.activities = JsonConvert.SerializeObject(activities);
            return View();
        }
        public JsonResult AddActivity(Activity a)
        {
            if (Boolean.Parse(ConfigurationManager.AppSettings["IsDebug"]))
            {
                a.CreatedBy = 1;
                a.Person = uow.People.Get(1);
            }
            else
            {
                a.CreatedBy = Convert.ToInt64(Session["UserID"]);
                a.Person = uow.People.Get(Convert.ToInt64(Session["UserID"]));
            }
            uow.Activities.Add(a);
            uow.Complete();
            return Json(new { ID = a.ID });
        }

        public void RemoveActivity(Activity a)
        {
            a = uow.Activities.Find(ac => ac.ID == a.ID && ac.Date == a.Date && ac.StartTime == a.StartTime && ac.EndTime == a.EndTime).First();
            if (a != null)
            {
                uow.Activities.Remove(a);
                uow.Complete();
            }
        }

    }
}