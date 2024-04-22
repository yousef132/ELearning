using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Data.Migrations
{
    /// <inheritdoc />
    public partial class addcoursecolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Course_CourseId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Assignment_AssignmentId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Course_CourseId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseQuestion_Exam_ExamId",
                table: "BaseQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_UserId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Course_CourseId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignment_AspNetUsers_UserId",
                table: "StudentAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignment_Assignment_AssignmentId",
                table: "StudentAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_AspNetUsers_UserId",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Course_CourseId",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExam_AspNetUsers_UserId",
                table: "StudentExam");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExam_Exam_ExamId",
                table: "StudentExam");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestion_AspNetUsers_UserId",
                table: "StudentQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestion_BaseQuestion_BaseQuestionId",
                table: "StudentQuestion");

            migrationBuilder.DropTable(
                name: "Choice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentQuestion",
                table: "StudentQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentExam",
                table: "StudentExam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssignment",
                table: "StudentAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseQuestion",
                table: "BaseQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment");

            migrationBuilder.RenameTable(
                name: "StudentQuestion",
                newName: "StudentQuestions");

            migrationBuilder.RenameTable(
                name: "StudentExam",
                newName: "StudentExams");

            migrationBuilder.RenameTable(
                name: "StudentCourse",
                newName: "StudentCourses");

            migrationBuilder.RenameTable(
                name: "StudentAssignment",
                newName: "StudentAssignments");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "Exams");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "BaseQuestion",
                newName: "BaseQuestions");

            migrationBuilder.RenameTable(
                name: "Attachment",
                newName: "Attachments");

            migrationBuilder.RenameTable(
                name: "Assignment",
                newName: "Assignments");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuestion_BaseQuestionId",
                table: "StudentQuestions",
                newName: "IX_StudentQuestions_BaseQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExam_ExamId",
                table: "StudentExams",
                newName: "IX_StudentExams_ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAssignment_AssignmentId",
                table: "StudentAssignments",
                newName: "IX_StudentAssignments_AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_CourseId",
                table: "Exams",
                newName: "IX_Exams_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_UserId",
                table: "Courses",
                newName: "IX_Courses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseQuestion_ExamId",
                table: "BaseQuestions",
                newName: "IX_BaseQuestions_ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachment_CourseId",
                table: "Attachments",
                newName: "IX_Attachments_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachment_AssignmentId",
                table: "Attachments",
                newName: "IX_Attachments_AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignment_CourseId",
                table: "Assignments",
                newName: "IX_Assignments_CourseId");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Duration",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Courses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SkillLevel",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentQuestions",
                table: "StudentQuestions",
                columns: new[] { "UserId", "BaseQuestionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentExams",
                table: "StudentExams",
                columns: new[] { "UserId", "ExamId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                columns: new[] { "UserId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssignments",
                table: "StudentAssignments",
                columns: new[] { "UserId", "AssignmentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseQuestions",
                table: "BaseQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseQuestionId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Courses_CourseId",
                table: "Assignments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Assignments_AssignmentId",
                table: "Attachments",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Courses_CourseId",
                table: "Attachments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseQuestions_Exams_ExamId",
                table: "BaseQuestions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_UserId",
                table: "Courses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_CourseId",
                table: "Exams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignments_AspNetUsers_UserId",
                table: "StudentAssignments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignments_Assignments_AssignmentId",
                table: "StudentAssignments",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_AspNetUsers_UserId",
                table: "StudentCourses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExams_AspNetUsers_UserId",
                table: "StudentExams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExams_Exams_ExamId",
                table: "StudentExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

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
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Courses_CourseId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Assignments_AssignmentId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Courses_CourseId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseQuestions_Exams_ExamId",
                table: "BaseQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_UserId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_CourseId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignments_AspNetUsers_UserId",
                table: "StudentAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignments_Assignments_AssignmentId",
                table: "StudentAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_AspNetUsers_UserId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExams_AspNetUsers_UserId",
                table: "StudentExams");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExams_Exams_ExamId",
                table: "StudentExams");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestions_AspNetUsers_UserId",
                table: "StudentQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestions_BaseQuestions_BaseQuestionId",
                table: "StudentQuestions");

            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentQuestions",
                table: "StudentQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentExams",
                table: "StudentExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAssignments",
                table: "StudentAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseQuestions",
                table: "BaseQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Assignments");

            migrationBuilder.RenameTable(
                name: "StudentQuestions",
                newName: "StudentQuestion");

            migrationBuilder.RenameTable(
                name: "StudentExams",
                newName: "StudentExam");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                newName: "StudentCourse");

            migrationBuilder.RenameTable(
                name: "StudentAssignments",
                newName: "StudentAssignment");

            migrationBuilder.RenameTable(
                name: "Exams",
                newName: "Exam");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "BaseQuestions",
                newName: "BaseQuestion");

            migrationBuilder.RenameTable(
                name: "Attachments",
                newName: "Attachment");

            migrationBuilder.RenameTable(
                name: "Assignments",
                newName: "Assignment");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuestions_BaseQuestionId",
                table: "StudentQuestion",
                newName: "IX_StudentQuestion_BaseQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExams_ExamId",
                table: "StudentExam",
                newName: "IX_StudentExam_ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourse",
                newName: "IX_StudentCourse_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAssignments_AssignmentId",
                table: "StudentAssignment",
                newName: "IX_StudentAssignment_AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_CourseId",
                table: "Exam",
                newName: "IX_Exam_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_UserId",
                table: "Course",
                newName: "IX_Course_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseQuestions_ExamId",
                table: "BaseQuestion",
                newName: "IX_BaseQuestion_ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_CourseId",
                table: "Attachment",
                newName: "IX_Attachment_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_AssignmentId",
                table: "Attachment",
                newName: "IX_Attachment_AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_CourseId",
                table: "Assignment",
                newName: "IX_Assignment_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentQuestion",
                table: "StudentQuestion",
                columns: new[] { "UserId", "BaseQuestionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentExam",
                table: "StudentExam",
                columns: new[] { "UserId", "ExamId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse",
                columns: new[] { "UserId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAssignment",
                table: "StudentAssignment",
                columns: new[] { "UserId", "AssignmentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseQuestion",
                table: "BaseQuestion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Choice",
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
                    table.PrimaryKey("PK_Choice", x => new { x.BaseQuestionId, x.Id });
                    table.ForeignKey(
                        name: "FK_Choice_BaseQuestion_BaseQuestionId",
                        column: x => x.BaseQuestionId,
                        principalTable: "BaseQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Course_CourseId",
                table: "Assignment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Assignment_AssignmentId",
                table: "Attachment",
                column: "AssignmentId",
                principalTable: "Assignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Course_CourseId",
                table: "Attachment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseQuestion_Exam_ExamId",
                table: "BaseQuestion",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_UserId",
                table: "Course",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Course_CourseId",
                table: "Exam",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignment_AspNetUsers_UserId",
                table: "StudentAssignment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignment_Assignment_AssignmentId",
                table: "StudentAssignment",
                column: "AssignmentId",
                principalTable: "Assignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_AspNetUsers_UserId",
                table: "StudentCourse",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Course_CourseId",
                table: "StudentCourse",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExam_AspNetUsers_UserId",
                table: "StudentExam",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExam_Exam_ExamId",
                table: "StudentExam",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestion_AspNetUsers_UserId",
                table: "StudentQuestion",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestion_BaseQuestion_BaseQuestionId",
                table: "StudentQuestion",
                column: "BaseQuestionId",
                principalTable: "BaseQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
