using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApp.Models
{

    public class ErrorController : Controller
    {
        private readonly ILog log;

        public ErrorController()
        {

        }

        public ErrorController(ILog log)
        {
            this.log = log;
        }

        public ActionResult PageError()
        {
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            log.Error("404");
            return View("Page404");
        }
        public ActionResult Page403()
        {
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            log.Error("403");
            return View("Page403");
        }
        public ActionResult Page500()
        {
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
            log.Error("500");
            return View("Page500");
        }
    }

}