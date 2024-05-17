using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practices.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoundationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "EmployeeCount", "FoundationDate", "Name", "Password", "Website" },
                values: new object[,]
                {
                    { 1, "100", new DateTime(2022, 1, 3, 13, 54, 18, 0, DateTimeKind.Unspecified), "Ryanair", "ryanair12345", true },
                    { 2, "50", new DateTime(2021, 1, 3, 13, 54, 48, 0, DateTimeKind.Unspecified), "Vueling", "vueling12345", false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DNI", "Email", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, "32452464D", "mario@gmail.com", "Mario", "mario12345", "4574" },
                    { 2, "23523562D", "carlos@gmail.com", "Carlos", "carlos12345", "4567477" },
                    { 3, "23526445X", "fernando@gmail.com", "Fernando", "fernando12345", "4745" },
                    { 4, "52353425D", "eduardo@gmail.com", "Eduardo", "eduardo12345", "4574548" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Amount", "CompanyId", "DepartureDate", "Destination", "Origin", "ReturnDate", "UserId" },
                values: new object[] { 1, 90.0, 1, new DateTime(2023, 1, 3, 13, 54, 48, 0, DateTimeKind.Unspecified), "Japón", "España", new DateTime(2024, 1, 3, 13, 54, 48, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Amount", "CompanyId", "DepartureDate", "Destination", "Origin", "ReturnDate", "UserId" },
                values: new object[] { 2, 70.0, 2, new DateTime(2023, 1, 3, 13, 54, 48, 0, DateTimeKind.Unspecified), "EEUU", "España", new DateTime(2024, 1, 3, 13, 54, 48, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Amount", "CompanyId", "DepartureDate", "Destination", "Origin", "ReturnDate", "UserId" },
                values: new object[] { 3, 30.0, 1, new DateTime(2023, 1, 3, 13, 54, 48, 0, DateTimeKind.Unspecified), "Islas Canarias", "Argentina", new DateTime(2024, 1, 3, 13, 54, 48, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CompanyId",
                table: "Bookings",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
