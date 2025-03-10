using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApplicationTracker.Migrations
{
    /// <inheritdoc />
    public partial class DbCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateApplied = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "ID", "CompanyName", "DateApplied", "Position", "Status" },
                values: new object[,]
                {
                    { 1, "Alpha", new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Developer", "Progress" },
                    { 2, "Beta", new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Developer", "Progress" },
                    { 3, "Beta", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Developer", "Rejected" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
