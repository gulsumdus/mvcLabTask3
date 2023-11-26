using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVClab3.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaryInfoTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Net = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gross = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryInfoTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryInfoTable");
        }
    }
}
