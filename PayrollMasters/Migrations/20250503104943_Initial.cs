using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollService.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendanceTypes",
                columns: table => new
                {
                    AttendanceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendenceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceTypes", x => x.AttendanceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeGroups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "PayrollVouchers",
                columns: table => new
                {
                    VoucherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollVouchers", x => x.VoucherId);
                });

            migrationBuilder.CreateTable(
                name: "PayHeads",
                columns: table => new
                {
                    PayHeadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalculationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FixedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AttendanceTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayHeads", x => x.PayHeadId);
                    table.ForeignKey(
                        name: "FK_PayHeads_AttendanceTypes_AttendanceTypeId",
                        column: x => x.AttendanceTypeId,
                        principalTable: "AttendanceTypes",
                        principalColumn: "AttendanceTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IFSC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "EmployeeGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendances",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AttendanceTypeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendances", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendances_AttendanceTypes_AttendanceTypeId",
                        column: x => x.AttendanceTypeId,
                        principalTable: "AttendanceTypes",
                        principalColumn: "AttendanceTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendances_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePayHeadAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PayHeadId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPercentage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayHeadAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePayHeadAssignments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePayHeadAssignments_PayHeads_PayHeadId",
                        column: x => x.PayHeadId,
                        principalTable: "PayHeads",
                        principalColumn: "PayHeadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayrollVoucherEntrys",
                columns: table => new
                {
                    EntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TotalEarnings = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDeductions = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollVoucherEntrys", x => x.EntryId);
                    table.ForeignKey(
                        name: "FK_PayrollVoucherEntrys_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollVoucherEntrys_PayrollVouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "PayrollVouchers",
                        principalColumn: "VoucherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayrollVoucherBreakups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryId = table.Column<int>(type: "int", nullable: false),
                    PayHeadId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollVoucherBreakups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollVoucherBreakups_PayHeads_PayHeadId",
                        column: x => x.PayHeadId,
                        principalTable: "PayHeads",
                        principalColumn: "PayHeadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollVoucherBreakups_PayrollVoucherEntrys_EntryId",
                        column: x => x.EntryId,
                        principalTable: "PayrollVoucherEntrys",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendances_AttendanceTypeId",
                table: "EmployeeAttendances",
                column: "AttendanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendances_EmployeeId",
                table: "EmployeeAttendances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayHeadAssignments_EmployeeId",
                table: "EmployeePayHeadAssignments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayHeadAssignments_PayHeadId",
                table: "EmployeePayHeadAssignments",
                column: "PayHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GroupId",
                table: "Employees",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PayHeads_AttendanceTypeId",
                table: "PayHeads",
                column: "AttendanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollVoucherBreakups_EntryId",
                table: "PayrollVoucherBreakups",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollVoucherBreakups_PayHeadId",
                table: "PayrollVoucherBreakups",
                column: "PayHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollVoucherEntrys_EmployeeId",
                table: "PayrollVoucherEntrys",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollVoucherEntrys_VoucherId",
                table: "PayrollVoucherEntrys",
                column: "VoucherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAttendances");

            migrationBuilder.DropTable(
                name: "EmployeePayHeadAssignments");

            migrationBuilder.DropTable(
                name: "PayrollVoucherBreakups");

            migrationBuilder.DropTable(
                name: "PayHeads");

            migrationBuilder.DropTable(
                name: "PayrollVoucherEntrys");

            migrationBuilder.DropTable(
                name: "AttendanceTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PayrollVouchers");

            migrationBuilder.DropTable(
                name: "EmployeeGroups");
        }
    }
}
