using Microsoft.EntityFrameworkCore.Migrations;

namespace MyQuiz.Data.Migrations
{
    public partial class myname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserQuizzes_QuizId",
                table: "UserQuizzes",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuizzes_Quizzes_QuizId",
                table: "UserQuizzes",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuizzes_Quizzes_QuizId",
                table: "UserQuizzes");

            migrationBuilder.DropIndex(
                name: "IX_UserQuizzes_QuizId",
                table: "UserQuizzes");
        }
    }
}
