using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyQuiz.Models
{
    public class Description
    {
      
        [Key]
        public int QuizId { get; set; }
        public string Describe { get; set; }
        public string Image { get; set; }

        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }
    }
}
