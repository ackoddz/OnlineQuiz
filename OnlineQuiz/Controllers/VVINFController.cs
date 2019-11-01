using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineQuiz.Models;
namespace OnlineQuiz.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class VVINFController : Controller
    {
        // GET: VVINF
        Q_Context db = new Q_Context();
        List<int> generated_questions = new List<int>();
        static Random rand = new Random();

        public ActionResult Index()
        {
            var questions = db.Questions.Where(p => p.subject == "VVINF").ToList();
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
            var questions = db.Questions.Where(p => p.subject == "VVINF");
            return View(questions);
        }
    }
}