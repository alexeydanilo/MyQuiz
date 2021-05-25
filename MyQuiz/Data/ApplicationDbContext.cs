using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyQuiz.Models;


namespace MyQuiz.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserQuiz>()
         .HasKey(c => new { c.UserId, c.QuizId });
            modelBuilder.Entity<Description>().HasKey(x => x.QuizId);

        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<UserQuiz> UserQuizzes { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }

     
      

    }
}
