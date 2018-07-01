using Logger.BAL;
using System.Web.Mvc;
using System;
using Logger.DAL;
using System.Linq;
using Newtonsoft.Json;
using System.Configuration;

namespace LoggerPortal.Controllers
{
    public class FinanceController : Controller
    {
        private UnitOfWork uow = new UnitOfWork(new DBEntities());

        // GET: Finance
        public ActionResult Index()
        {
           var transactions = uow.Transactions.GetAll().ToList();//.Find(t => t.DateCreated == DateTime.Now).ToList();
           ViewBag.transactions = JsonConvert.SerializeObject(transactions);
           return View();
        }

        public JsonResult AddTransaction(FinancialTransaction t)
        {
            t.DateModified = DateTime.Now;
            if(Boolean.Parse(ConfigurationManager.AppSettings["IsDebug"]))
            {
                t.CreatedBy = 1;
                t.Person = uow.Persons.Get(1);
            }
            else
            {
                t.CreatedBy = Convert.ToInt64(Session["UserID"]);
                t.Person = uow.Persons.Get(Convert.ToInt64(Session["UserID"]));
            }
            uow.Transactions.Add(t);
            uow.Complete();
            return Json(new { ID = t.ID });
        }

        public void RemoveTransaction(FinancialTransaction t)
        {
            t = uow.Transactions.Get(t.ID);
            uow.Transactions.Remove(t);
            uow.Complete();
        }
    }
}