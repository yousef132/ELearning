using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLecturesTableWithNewRelationsships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Courses_CourseId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Section_SectionId",
                table: "Attachments");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.RenameColumn(
                name: "Lectures",
                table: "Courses",
                newName: "NumberOfLectures");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Attachments",
                newName: "LectureId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_SectionId",
                table: "Attachments",
                newName: "IX_Attachments_LectureId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Assignments",
                newName: "LectureId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_CourseId",
                table: "Assignments",
                newName: "IX_Assignments_LectureId");

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate:ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseId",
                table: "Lectures",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Lectures_LectureId",
                table: "Assignments",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Lectures_LectureId",
                table: "Attachments",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Lectures_LectureId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Lectures_LectureId",
                table: "Attachments");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.RenameColumn(
                name: "NumberOfLectures",
                table: "Courses",
                newName: "Lectures");

            migrationBuilder.RenameColumn(
                name: "LectureId",
                table: "Attachments",
                newName: "SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_LectureId",
                table: "Attachments",
                newName: "IX_Attachments_SectionId");

            migrationBuilder.RenameColumn(
                name: "LectureId",
                table: "Assignments",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_LectureId",
                table: "Assignments",
                newName: "IX_Assignments_CourseId");

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Section_CourseId",
                table: "Section",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Courses_CourseId",
                table: "Assignments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Section_SectionId",
                table: "Attachments",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
