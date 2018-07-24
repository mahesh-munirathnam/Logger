using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Logger.BAL;
using Logger.DAL.Domain;
using LoggerPortal.Models;

namespace LoggerPortal.Controllers
{
    public class AccessController : Controller
    {
        [AllowAnonymous]
        public ActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enter(Login login)
        {
            if (ModelState.IsValid)
            {
                using (var UnitOfWork = new UnitOfWork(new DBEntities()))
                {
                    var user = UnitOfWork.People.ValidUser(login.Email, login.Password);
                    if (user != null)
                    {
                        Session["UserID"] = user.PersonId;
                        Session["UserName"] = user.Name;
                        FormsAuthentication.SetAuthCookie(user.PersonId.ToString(), false);
                        var authTicket = new FormsAuthenticationTicket(1, user.PersonId.ToString(), DateTime.Now, DateTime.Now.AddMinutes(20), false,user.Name);
                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        HttpContext.Response.Cookies.Add(authCookie);
                        UnitOfWork.Complete();
                        return RedirectToAction("DashBoard", "Home");
                    }
                }
            }
            return View(login);
        }
        
        public ActionResult Exit()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Enter", "Access");
        }
    }
}