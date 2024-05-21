using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BaseQuestionId",
                table: "StudentAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BaseQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Choice1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Choice2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Choice3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Choice4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerChoice = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_StudentAnswers_BaseQuestionId",
                table: "StudentAnswers",
                column: "BaseQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseQuestions_ExamId",
                table: "BaseQuestions",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_BaseQuestions_BaseQuestionId",
                table: "StudentAnswers",
                column: "BaseQuestionId",
                principalTable: "BaseQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_BaseQuestions_BaseQuestionId",
                table: "StudentAnswers");

            migrationBuilder.DropTable(
                name: "BaseQuestions");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_BaseQuestionId",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "BaseQuestionId",
                table: "StudentAnswers");
        }
    }
}
