using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarBookingSystem.Migrations
{
    public partial class Initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassID", "Capacity", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2024, 4, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 8, new DateTime(2024, 4, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 26, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 12, new DateTime(2024, 4, 27, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 6, new DateTime(2024, 4, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 28, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 15, new DateTime(2024, 4, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 29, 11, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassID",
                table: "Students",
                column: "ClassID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
