using System.Collections.Generic;
using MyQuiz.Models;

namespace MyQuiz.ViewModels
{
    public class TestViewModel
    {
        public IEnumerable<Question>  Questions{ get; set; }
        public string Button { get; set; }
      

    }
}
