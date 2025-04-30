using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAndAccountingServices.Migrations
{
    /// <inheritdoc />
    public partial class InentoryLedgerUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankLedgerDetails",
                columns: table => new
                {
                    LedgerId = table.Column<int>(type: "int", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IFSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankLedgerDetails", x => x.LedgerId);
                    table.ForeignKey(
                        name: "FK_BankLedgerDetails_InventoryLedgers_LedgerId",
                        column: x => x.LedgerId,
                        principalTable: "InventoryLedgers",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillByBillDetails",
                columns: table => new
                {
                    LedgerId = table.Column<int>(type: "int", nullable: false),
                    IsBillByBillEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreditPeriod = table.Column<int>(type: "int", nullable: false),
                    ReferenceType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillByBillDetails", x => x.LedgerId);
                    table.ForeignKey(
                        name: "FK_BillByBillDetails_InventoryLedgers_LedgerId",
                        column: x => x.LedgerId,
                        principalTable: "InventoryLedgers",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GstLedgerDetails",
                columns: table => new
                {
                    LedgerId = table.Column<int>(type: "int", nullable: false),
                    GstType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GstRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HsnSacCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GstLedgerDetails", x => x.LedgerId);
                    table.ForeignKey(
                        name: "FK_GstLedgerDetails_InventoryLedgers_LedgerId",
                        column: x => x.LedgerId,
                        principalTable: "InventoryLedgers",
                        principalColumn: "LedgerId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankLedgerDetails");

            migrationBuilder.DropTable(
                name: "BillByBillDetails");

            migrationBuilder.DropTable(
                name: "GstLedgerDetails");
        }
    }
}
