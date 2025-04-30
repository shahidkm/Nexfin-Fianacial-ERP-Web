using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyServices.Migrations
{
    /// <inheritdoc />
    public partial class CompanyRoleEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "CompanyRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "CompanyRoles");
        }
    }
}
