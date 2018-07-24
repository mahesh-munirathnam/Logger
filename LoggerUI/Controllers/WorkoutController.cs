using Logger.BAL;
using Logger.DAL.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoggerUI.Filters;

namespace LoggerPortal.Controllers
{   
    [SessionFilter]            
    public class WorkoutController : Controller
    {
        private UnitOfWork uow = new UnitOfWork(new DBEntities());

        // GET: Workout
        public ActionResult Index()
        {
            var workouts = uow.Workouts.GetAll().ToList();//.Find(t => t.DateCreated == DateTime.Now).ToList();
            ViewBag.workouts = JsonConvert.SerializeObject(workouts);
            return View();
        }

        public JsonResult AddWorkout(Workout w)
        {
            if (Boolean.Parse(ConfigurationManager.AppSettings["IsDebug"]))
            {
                w.CreatedBy = 1;
                w.Person = uow.People.Get(1);
            }
            else
            {
                w.CreatedBy = Convert.ToInt64(Session["UserID"]);
                w.Person = uow.People.Get(Convert.ToInt64(Session["UserID"]));
            }
            uow.Workouts.Add(w);
            uow.Complete();
            return Json(new { ID = w.ID });
        }

        public void RemoveWorkout(Workout w)
        {
            w = uow.Workouts.Get(w.ID);
            if (w != null)
            {
                uow.Workouts.Remove(w);
                uow.Complete();
            }
        }

    }
}