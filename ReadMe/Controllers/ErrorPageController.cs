﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadMe.Controllers
{
    public class ErrorPageController : Controller
    {
        //
        // GET: /ErrorPage/
        public ActionResult ErrorMessage()
        {
            return View();
        }
	}
}