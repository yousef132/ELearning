using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIdColumnToStudentAssignmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentAssignments");
        }
    }
}
