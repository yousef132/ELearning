using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSectiontTableAndEditAttachmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Assignments_AssignmentId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Courses_CourseId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_CourseId",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Attachments",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AssignmentId",
                table: "Attachments",
                newName: "SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_AssignmentId",
                table: "Attachments",
                newName: "IX_Attachments_SectionId");

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
                name: "FK_Attachments_Section_SectionId",
                table: "Attachments",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Section_SectionId",
                table: "Attachments");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Attachments",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Attachments",
                newName: "AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_SectionId",
                table: "Attachments",
                newName: "IX_Attachments_AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CourseId",
                table: "Attachments",
                column: "CourseId");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
