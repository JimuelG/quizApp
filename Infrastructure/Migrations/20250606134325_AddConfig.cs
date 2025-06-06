using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Questions_QuestionId",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_StudentQuizzes_StudentQuizId",
                table: "StudentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_QuestionId",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "StudentAnswers");

            migrationBuilder.RenameColumn(
                name: "TakenAt",
                table: "StudentQuizzes",
                newName: "DateTaken");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "StudentQuizzes",
                newName: "TotalQuestions");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentAnswers",
                newName: "AnswerGiven");

            migrationBuilder.AddColumn<int>(
                name: "CorrectAnswers",
                table: "StudentQuizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ScorePercentage",
                table: "StudentQuizzes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "StudentQuizId",
                table: "StudentAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_StudentQuizzes_StudentQuizId",
                table: "StudentAnswers",
                column: "StudentQuizId",
                principalTable: "StudentQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_StudentQuizzes_StudentQuizId",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "CorrectAnswers",
                table: "StudentQuizzes");

            migrationBuilder.DropColumn(
                name: "ScorePercentage",
                table: "StudentQuizzes");

            migrationBuilder.RenameColumn(
                name: "TotalQuestions",
                table: "StudentQuizzes",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "DateTaken",
                table: "StudentQuizzes",
                newName: "TakenAt");

            migrationBuilder.RenameColumn(
                name: "AnswerGiven",
                table: "StudentAnswers",
                newName: "StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "StudentQuizId",
                table: "StudentAnswers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "StudentAnswers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_QuestionId",
                table: "StudentAnswers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Questions_QuestionId",
                table: "StudentAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_StudentQuizzes_StudentQuizId",
                table: "StudentAnswers",
                column: "StudentQuizId",
                principalTable: "StudentQuizzes",
                principalColumn: "Id");
        }
    }
}
