using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineQuiz.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;
namespace OnlineQuiz.Controllers
{
    
    public class ONVDController : Controller
    {
        // GET: ONVD
        Q_Context db = new Q_Context();
        List<int> generated_questions = new List<int>();
        static Random rand = new Random();
        ApplicationUserManager _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        ApplicationDbContext db_appContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            var questions = db.Questions.Where(p => p.subject == "ONVD").ToList();        
            var sessionQuestions = questions.OrderBy(item => rand.Next()).Take(10);
            myModel model = new myModel
            {
                Questions = questions,
                randomSample = sessionQuestions,
            };
            return View(model);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> processAnswer(string[] questionAnswer)
        {
            // 1 _ansone
            // 1 _ansone
            // 2 _anstwo
            // 3_ansthree
            var score = 0;
            if (questionAnswer == null)
            {
                ViewBag.Score = 0;
                return View();
            }
            foreach (var item in questionAnswer)
            {
                int id = Convert.ToInt32(item.Split('_')[0].Trim());
                string answer = item.Split('_')[1].Trim();
                string correct_answer = db.Questions.First(q => q.Id == id).correctAnswer;
                if (answer == correct_answer)
                    score += 10;
                else
                    score -= 5;

            }
            ApplicationUser model = _userManager.FindById(User.Identity.GetUserId());
            model.Points = model.Points + score;
            IdentityResult result = await _userManager.UpdateAsync(model);


            ViewBag.Score = score;

            return View();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult List()
        {
            var questions = db.Questions.Where(p => p.subject == "ONVD");
            return View(questions);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question q = db.Questions.Find(id);
            if (q == null)
            {
                return HttpNotFound();
            }
            return View(q);
        }
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Question q = db.Questions.Find(id);
            db.Questions.Remove(q);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Question q)
        {
            if (ModelState.IsValid)
            {
                q.subject = "ONVD";
                db.Questions.Add(q);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("List");
            }
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question q = db.Questions.Find(id);
            if (q == null)
            {
                return HttpNotFound();
            }
            return View(q);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Question q)
        {
            if (ModelState.IsValid)
            {
                q.subject = "ONVD";
                db.Entry(q).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(q);
        }
    }
}