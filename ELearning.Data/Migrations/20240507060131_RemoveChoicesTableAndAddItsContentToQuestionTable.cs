using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveChoicesTableAndAddItsContentToQuestionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropColumn(
                name: "StudentAnswerId",
                table: "StudentQuestions");

            migrationBuilder.RenameColumn(
                name: "RightAnswer",
                table: "BaseQuestions",
                newName: "AnswerChoice");

            migrationBuilder.AddColumn<bool>(
                name: "AnswerIsCorrect",
                table: "StudentQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Choice1",
                table: "BaseQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Choice2",
                table: "BaseQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Choice3",
                table: "BaseQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Choice4",
                table: "BaseQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerIsCorrect",
                table: "StudentQuestions");

            migrationBuilder.DropColumn(
                name: "Choice1",
                table: "BaseQuestions");

            migrationBuilder.DropColumn(
                name: "Choice2",
                table: "BaseQuestions");

            migrationBuilder.DropColumn(
                name: "Choice3",
                table: "BaseQuestions");

            migrationBuilder.DropColumn(
                name: "Choice4",
                table: "BaseQuestions");

            migrationBuilder.RenameColumn(
                name: "AnswerChoice",
                table: "BaseQuestions",
                newName: "RightAnswer");

            migrationBuilder.AddColumn<int>(
                name: "StudentAnswerId",
                table: "StudentQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    BaseQuestionId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => new { x.BaseQuestionId, x.Id });
                    table.ForeignKey(
                        name: "FK_Choices_BaseQuestions_BaseQuestionId",
                        column: x => x.BaseQuestionId,
                        principalTable: "BaseQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
