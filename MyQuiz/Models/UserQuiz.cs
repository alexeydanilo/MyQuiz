

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MyQuiz.Models
{
    public class UserQuiz
    {
        public string UserId { get; set; }
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }


        //  public virtual IdentityUser IdentityUser { get; set; }

    }
}
