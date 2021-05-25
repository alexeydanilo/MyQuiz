using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyQuiz.Data;
using System.Security.Claims;
using MyQuiz.Models;



namespace MyQuiz.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }
    
        static int score = 0;
        static bool complition = false;
        public IActionResult Quizzes(int id)
        {
            return View("Quizzes/Quiz" + id);
        }
        public IActionResult ListQuiz()
        {

            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var userquizid = _context.UserQuizzes.Where(x => x.UserId == userId).Select(a => a.QuizId).ToHashSet();

            var usersquiz = _context.Quizzes.Where(x => userquizid.Contains(x.Id)).ToList();

            if(usersquiz.Count == 0)
            {
                return View("Quizzes/NoTests");
            }

            return View(usersquiz);
        }



        public IActionResult Test(int? id, int quizid)
        {
            PageViewModel viewModel = new PageViewModel();

            viewModel.Button = "Далее";
            ViewBag.QuizId = quizid;
          
            
            if (complition)
            {
                ViewBag.Score = score;
                complition = false;
                return View("Result");
                
            }
            
            if (!id.HasValue)
            {
                id = _context.Questions.Where(x => x.QuizId == quizid).Select(a => a.Id).First();
            }
            
            viewModel.Questions = _context.Questions.Where(x => x.QuizId == quizid && x.Id == id).ToList();

            if (viewModel.Questions.Count() == 0)
            {
                viewModel.Questions = _context.Questions.Where(x => x.QuizId == quizid && x.Id == id + 1).ToList();
                id++;
            }
            if (id > (_context.Questions.Where(x => x.QuizId == quizid).OrderBy(a => a.Id).Last().Id - 1))
            {
                viewModel.Button = "Завершить";
                complition = true;
            }

            ViewBag.Id = id;

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Test(int value, int quizid, IFormCollection iformCollection)
        {
            value++;
            string[] questionIds = iformCollection["questionId"];
            foreach (var questionId in questionIds)
            {
                int anwerIdCorrect = _context.Questions.Find(int.Parse(questionId))
                    .Answers.Where(a => a.Correct == true).FirstOrDefault().Id;
                if (anwerIdCorrect == int.Parse(iformCollection["question_" + questionId]))
                {
                    score++;
                }
            }

           return RedirectToAction("Test", new { id = value, quizid = quizid });
        }

    }
}
