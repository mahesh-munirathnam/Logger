using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using LoggerUI.Models;
using Logger.BAL;
using Logger.DAL.Domain;
using Newtonsoft.Json;
using System.Configuration;
using LoggerUI.Filters;

namespace LoggerUI.Controllers
{
    [Authorize]
    [SessionFilter]
    public class PeopleController : Controller
    {

        private UnitOfWork uow = new UnitOfWork(new DBEntities());

        [AccessFilter]
        public ActionResult Index()
        {
            var people = uow.People.GetAll().ToList();
            ViewBag.people = JsonConvert.SerializeObject(people);

            var permissions = uow.Permissions.GetAll().ToList();
            ViewBag.permissions = JsonConvert.SerializeObject(permissions);
            return View();
        }

        [AccessFilter]
        public ActionResult Permissions()
        {
            return View();
        }

        [AccessFilter]
        public ActionResult PersonPermission()
        {
            return View();
        }

        public JsonResult AddPerson(Person p)
        {
            p.DateModified = DateTime.Now;
            if (Boolean.Parse(ConfigurationManager.AppSettings["IsDebug"]))
            {
                p.CreatedBy = 1;
            }
            else
            {
                p.CreatedBy = Convert.ToInt64(Session["UserID"]);
            }

            uow.People.Add(p);
            uow.Complete();
            return Json(new { ID = p.PersonId });
        }

        public void RemovePerson(Person p)
        {
            p = uow.People.Get(p.PersonId);
            p.Is_Active = false;
            uow.Complete();
        }

        public JsonResult AddPermission(Permission p)
        {
            if (Boolean.Parse(ConfigurationManager.AppSettings["IsDebug"]))
            {
                p.CreatedBy = 1;
            }
            else
            {
                p.CreatedBy = Convert.ToInt64(Session["UserID"]);
            }
            uow.Permissions.Add(p);
            uow.Complete();
            return Json(new { ID = p.PermissionId });
        }

        #region Helpers

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        #endregion
    }
}
