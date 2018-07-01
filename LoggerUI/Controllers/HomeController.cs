using Logger.BAL;
using Logger.BAL.Interfaces;
using Logger.DAL;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LoggerPortal.Controllers
{
    public class HomeController : Controller
    {

        private UnitOfWork uow = new UnitOfWork(new DBEntities());

        public ActionResult DashBoard()
        {
            var TotalIncome = uow.Transactions.Find(t => t.TransactionTypeID == (long)TransactionTypes.Income && t.DateCreated.Month == DateTime.Now.Month).Sum(t => t.Amount);
            var TotalExpenditure = uow.Transactions.Find(t => t.TransactionTypeID == (long)TransactionTypes.Expenditure && t.DateCreated.Month == DateTime.Now.Month).Sum(t => t.Amount);
            ViewBag.TIncome = JsonConvert.SerializeObject(TotalIncome);
            ViewBag.TExpenditure = JsonConvert.SerializeObject(TotalExpenditure);
            return View();
        }


        public JsonResult GetMontlyFinance(int month)
        {
            var TotalIncome = uow.Transactions.Find(t => t.TransactionTypeID == (long)TransactionTypes.Income && t.DateCreated.Month == month).Sum(t => t.Amount);
            var TotalExpenditure = uow.Transactions.Find(t => t.TransactionTypeID == (long)TransactionTypes.Expenditure && t.DateCreated.Month == month).Sum(t => t.Amount);

            return Json(new { TIncome = TotalIncome , TExpenditure = TotalExpenditure });
        }


    }
}