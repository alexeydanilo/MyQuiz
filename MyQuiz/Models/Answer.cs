using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyQuiz.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool? Correct { get; set; }
        public int? QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
