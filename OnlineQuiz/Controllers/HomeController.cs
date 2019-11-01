using OnlineQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineQuiz.Controllers
{
    public class HomeController : Controller
    {

        Q_Context db = new Q_Context();

        public ActionResult Index()
        {   
            return View();
        }
    }
}