using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDurtationColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimedEntity_Duration",
                table: "Exams",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimedEntity_Duration",
                table: "Assignments",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimedEntity_Duration",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "TimedEntity_Duration",
                table: "Assignments");
        }
    }
}
