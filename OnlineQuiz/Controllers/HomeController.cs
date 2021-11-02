using OnlineQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineQuiz.Controllers
{
    
      
    public class HomeController : Controller
    {

        Q_Context db = new Q_Context();
        ApplicationUserManager _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        ApplicationDbContext db_appContext = new ApplicationDbContext();

        [Authorize(Roles = "User,Administrator")]
        public ActionResult Index()
        {
            // var userId = HttpContext.User.Identity.GetUserId();
            // var userEmail = _userManager.FindById(userId).Email;
            // ViewData["currentUser"] = userEmail;

            var currentUserId = User.Identity.GetUserId();        
            var currentUser = _userManager.FindById(currentUserId);
            
            ViewData["currentUserName"] = currentUser.Name;
            ViewData["currentUserSurname"] = currentUser.Surname;
            ViewData["currentUserPoints"] = currentUser.Points;
            ViewData["currentUserEmail"] = currentUser.Email;
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Users_Review()
        {
            var users = db_appContext.Users;
            return View(users);
        }
        [Authorize(Roles = "User,Administrator")]
        public ActionResult Leaderboard()
        {
            var users = db_appContext.Users.OrderByDescending(a => a.Points);
            return View(users);
        }
    }
}