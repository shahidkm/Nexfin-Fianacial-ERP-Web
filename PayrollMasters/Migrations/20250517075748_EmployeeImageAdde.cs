using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollService.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeImageAdde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "PayHeads",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "PayHeads");
        }
    }
}
