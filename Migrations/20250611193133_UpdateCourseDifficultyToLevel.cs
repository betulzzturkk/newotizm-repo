using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutismEducationPlatform.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCourseDifficultyToLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Children_ChildId",
                table: "Progresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Courses_CourseId",
                table: "Progresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Progresses",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Progresses",
                newName: "Progress");

            migrationBuilder.RenameIndex(
                name: "IX_Progresses_CourseId",
                table: "Progress",
                newName: "IX_Progress_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Progresses_ChildId",
                table: "Progress",
                newName: "IX_Progress_ChildId");

            migrationBuilder.AddColumn<int>(
                name: "DifficultyLevel",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Progress",
                table: "Progress",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActivityLogs_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Information",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsImportant = table.Column<bool>(type: "bit", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Information", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_ActivityId",
                table: "ActivityLogs",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_ChildId",
                table: "ActivityLogs",
                column: "ChildId");

            migrationBuilder.AddForeignKey(
                name: "FK_Progress_Children_ChildId",
                table: "Progress",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Progress_Courses_CourseId",
                table: "Progress",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progress_Children_ChildId",
                table: "Progress");

            migrationBuilder.DropForeignKey(
                name: "FK_Progress_Courses_CourseId",
                table: "Progress");

            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "Information");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Progress",
                table: "Progress");

            migrationBuilder.DropColumn(
                name: "DifficultyLevel",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Progress",
                newName: "Progresses");

            migrationBuilder.RenameIndex(
                name: "IX_Progress_CourseId",
                table: "Progresses",
                newName: "IX_Progresses_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Progress_ChildId",
                table: "Progresses",
                newName: "IX_Progresses_ChildId");

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Progresses",
                table: "Progresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_Children_ChildId",
                table: "Progresses",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_Courses_CourseId",
                table: "Progresses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
