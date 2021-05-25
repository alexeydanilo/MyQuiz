using System.Collections.Generic;


namespace MyQuiz.Models
{
    public class PageViewModel
    {
        public IEnumerable<Question>  Questions{ get; set; }
        public string Button { get; set; }

    }
}
