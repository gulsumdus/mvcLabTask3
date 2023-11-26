using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVClab3.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTable_CompanyId",
                table: "EmployeeTable",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTable_CompanyTable_CompanyId",
                table: "EmployeeTable",
                column: "CompanyId",
                principalTable: "CompanyTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTable_CompanyTable_CompanyId",
                table: "EmployeeTable");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTable_CompanyId",
                table: "EmployeeTable");
        }
    }
}
