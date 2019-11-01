using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineQuiz.Models;
namespace OnlineQuiz.Controllers
{
    public class AOKController : Controller
    {
        // GET: AOK
        Q_Context db = new Q_Context();
        List<int> generated_questions = new List<int>();
        static Random rand = new Random();

        public ActionResult Index()
        {
            var questions = db.Questions.Where(p => p.subject == "AOK").ToList();
            var sessionQuestions = questions.OrderBy(item => rand.Next()).Take(10);

            return View(sessionQuestions);
        }

        public ActionResult processAnswer()
        {
        
            return RedirectToAction("Index");
        }
        public ActionResult quizEnd()
        {

            // should return end view
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult List()
        {
            var questions = db.Questions.Where(p => p.subject == "AOK");
            return View(questions);
        }
    }
}