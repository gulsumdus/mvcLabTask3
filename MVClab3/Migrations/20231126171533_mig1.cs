using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVClab3.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CompanyTable",
                columns: new[] { "Id", "City", "Country", "Name", "Zipcode" },
                values: new object[,]
                {
                    { 1, "Cupertino", "USA", "Apple", "43595" },
                    { 2, "Istanbul", "TURKEY", "Vestel", "51379" },
                    { 3, "Stokholm", "SWEDEN", "H&M", "16079" },
                    { 4, "London", "UK", "HSBC", "16905" },
                    { 5, "Hangzhou", "CHINA", "Alibaba Group", "17000" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTable",
                columns: new[] { "Id", "BirthDate", "CompanyId", "Image", "Name", "Position", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1992, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "/images/Martin.jpg", "Martin", "Marketing Expert", "Simpson" },
                    { 2, new DateTime(1995, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "/images/Jacob.jpg", "Jacob", "Manager", "Hawk" },
                    { 3, new DateTime(2000, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "/images/Elizabeth.jpg", "Elizabeth", "Software Engineer", "Geil" },
                    { 4, new DateTime(1997, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "/images/Kate.jpg", "Kate", "Admin", "Metain" },
                    { 5, new DateTime(1990, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "/images/Michael.jpg", "Michael", "Marketing expert", "Cook" },
                    { 6, new DateTime(2001, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "/images/John.jpg", "John", "Software Engineer", "Snow" },
                    { 7, new DateTime(1999, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "/images/Nina.jpg", "Nina", "Software Engineer", "Soprano" },
                    { 8, new DateTime(2000, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "/images/Tina.jpg", "Tina", "Team Leader", "Fins" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyTable");

            migrationBuilder.DropTable(
                name: "EmployeeTable");
        }
    }
}
