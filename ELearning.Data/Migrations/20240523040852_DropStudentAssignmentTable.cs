using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Data.Migrations
{
    /// <inheritdoc />
    public partial class DropStudentAssignmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAssignments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentAssignments",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<double>(type: "float", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignments", x => new { x.UserId, x.AssignmentId });
                    table.ForeignKey(
                        name: "FK_StudentAssignments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignments_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignments_AssignmentId",
                table: "StudentAssignments",
                column: "AssignmentId");
        }
    }
}
