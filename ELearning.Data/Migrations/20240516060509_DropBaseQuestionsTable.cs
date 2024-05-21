using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Data.Migrations
{
    /// <inheritdoc />
    public partial class DropBaseQuestionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestions_AspNetUsers_UserId",
                table: "StudentQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestions_BaseQuestions_BaseQuestionId",
                table: "StudentQuestions");

            migrationBuilder.DropTable(
                name: "BaseQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentQuestions",
                table: "StudentQuestions");

            migrationBuilder.DropIndex(
                name: "IX_StudentQuestions_BaseQuestionId",
                table: "StudentQuestions");

            migrationBuilder.DropColumn(
                name: "BaseQuestionId",
                table: "StudentQuestions");

            migrationBuilder.RenameTable(
                name: "StudentQuestions",
                newName: "StudentAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuestions_UserId",
                table: "StudentAnswers",
                newName: "IX_StudentAnswers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAnswers",
                table: "StudentAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_AspNetUsers_UserId",
                table: "StudentAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_AspNetUsers_UserId",
                table: "StudentAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAnswers",
                table: "StudentAnswers");

            migrationBuilder.RenameTable(
                name: "StudentAnswers",
                newName: "StudentQuestions");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswers_UserId",
                table: "StudentQuestions",
                newName: "IX_StudentQuestions_UserId");

            migrationBuilder.AddColumn<int>(
                name: "BaseQuestionId",
                table: "StudentQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentQuestions",
                table: "StudentQuestions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BaseQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    AnswerChoice = table.Column<int>(type: "int", nullable: false),
                    Choice1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Choice2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Choice3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Choice4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseQuestions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestions_BaseQuestionId",
                table: "StudentQuestions",
                column: "BaseQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseQuestions_ExamId",
                table: "BaseQuestions",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestions_AspNetUsers_UserId",
                table: "StudentQuestions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestions_BaseQuestions_BaseQuestionId",
                table: "StudentQuestions",
                column: "BaseQuestionId",
                principalTable: "BaseQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
