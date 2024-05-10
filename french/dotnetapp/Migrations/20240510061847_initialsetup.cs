using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetapp.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    BatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.BatchID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Batches_BatchID",
                        column: x => x.BatchID,
                        principalTable: "Batches",
                        principalColumn: "BatchID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Batches",
                columns: new[] { "BatchID", "Capacity", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2024, 7, 9, 2, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 5, new DateTime(2024, 8, 18, 1, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 5, new DateTime(2024, 11, 26, 1, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 5, new DateTime(2025, 3, 6, 1, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 9, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, 5, new DateTime(2025, 6, 14, 1, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_BatchID",
                table: "Students",
                column: "BatchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Batches");
        }
    }
}
