﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoggerPortal.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult DashBoard()
        {
            return View();
        }
    }
}