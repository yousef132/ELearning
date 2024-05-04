using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeRelationBetweenLectureAndExamAndRemoveItFromCourseAndExam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_CourseId",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Exams",
                newName: "LectureId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_CourseId",
                table: "Exams",
                newName: "IX_Exams_LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Lectures_LectureId",
                table: "Exams",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Lectures_LectureId",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "LectureId",
                table: "Exams",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_LectureId",
                table: "Exams",
                newName: "IX_Exams_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_CourseId",
                table: "Exams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
