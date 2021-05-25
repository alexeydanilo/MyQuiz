using MyQuiz.Models;
using System.Collections.Generic;


namespace MyQuiz.ViewModels
{
    public class DescriptionTestViewModel
    {
        public IEnumerable<Quiz> Quizzes { get; set; }
        public IEnumerable<Description> Descriptions { get; set; }
        public int Id { get; set; }


    }
}
