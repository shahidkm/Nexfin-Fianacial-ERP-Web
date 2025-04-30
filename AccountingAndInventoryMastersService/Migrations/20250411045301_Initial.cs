using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountingAndInventoryMastersService.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentGroupId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryGroups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_InventoryGroups_InventoryGroups_ParentGroupId",
                        column: x => x.ParentGroupId,
                        principalTable: "InventoryGroups",
                        principalColumn: "GroupId");
                });

            migrationBuilder.CreateTable(
                name: "InventoryLedgers",
                columns: table => new
                {
                    LedgerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    LedgerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningBalance = table.Column<int>(type: "int", nullable: true),
                    DrCr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLedgers", x => x.LedgerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryGroups_ParentGroupId",
                table: "InventoryGroups",
                column: "ParentGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryGroups");

            migrationBuilder.DropTable(
                name: "InventoryLedgers");
        }
    }
}
