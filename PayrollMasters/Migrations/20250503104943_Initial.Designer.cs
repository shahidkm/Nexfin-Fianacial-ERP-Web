﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PayrollMasters.Infrastucture.Persistence.Data;

#nullable disable

namespace PayrollService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250503104943_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PayrollMasters.Domain.Entities.AttendanceType", b =>
                {
                    b.Property<int>("AttendanceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttendanceTypeId"));

                    b.Property<string>("AttendenceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttendanceTypeId");

                    b.ToTable("AttendanceTypes");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BasicSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfJoining")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("IFSC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("GroupId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.EmployeeAttendance", b =>
                {
                    b.Property<int>("AttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttendanceId"));

                    b.Property<int>("AttendanceTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("AttendanceId");

                    b.HasIndex("AttendanceTypeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeAttendances");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.EmployeeGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("EmployeeGroups");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.EmployeePayHeadAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsPercentage")
                        .HasColumnType("bit");

                    b.Property<int>("PayHeadId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PayHeadId");

                    b.ToTable("EmployeePayHeadAssignments");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.PayHead", b =>
                {
                    b.Property<int>("PayHeadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PayHeadId"));

                    b.Property<int?>("AttendanceTypeId")
                        .HasColumnType("int");

                    b.Property<string>("CalculationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("FixedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PayHeadId");

                    b.HasIndex("AttendanceTypeId");

                    b.ToTable("PayHeads");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.PayrollVoucher", b =>
                {
                    b.Property<int>("VoucherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoucherId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("VoucherNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VoucherId");

                    b.ToTable("PayrollVouchers");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.PayrollVoucherBreakup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("EntryId")
                        .HasColumnType("int");

                    b.Property<int>("PayHeadId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.HasIndex("PayHeadId");

                    b.ToTable("PayrollVoucherBreakups");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.PayrollVoucherEntry", b =>
                {
                    b.Property<int>("EntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntryId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalDeductions")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalEarnings")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VoucherId")
                        .HasColumnType("int");

                    b.HasKey("EntryId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VoucherId");

                    b.ToTable("PayrollVoucherEntrys");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.Employee", b =>
                {
                    b.HasOne("PayrollMasters.Domain.Entities.EmployeeGroup", "Group")
                        .WithMany("Employees")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.EmployeeAttendance", b =>
                {
                    b.HasOne("PayrollMasters.Domain.Entities.AttendanceType", "AttendanceType")
                        .WithMany()
                        .HasForeignKey("AttendanceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PayrollMasters.Domain.Entities.Employee", "Employee")
                        .WithMany("Attendances")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttendanceType");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.EmployeePayHeadAssignment", b =>
                {
                    b.HasOne("PayrollMasters.Domain.Entities.Employee", "Employee")
                        .WithMany("PayHeadAssignments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PayrollMasters.Domain.Entities.PayHead", "PayHead")
                        .WithMany()
                        .HasForeignKey("PayHeadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("PayHead");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.PayHead", b =>
                {
                    b.HasOne("PayrollMasters.Domain.Entities.AttendanceType", "AttendanceType")
                        .WithMany()
                        .HasForeignKey("AttendanceTypeId");

                    b.Navigation("AttendanceType");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.PayrollVoucherBreakup", b =>
                {
                    b.HasOne("PayrollMasters.Domain.Entities.PayrollVoucherEntry", "Entry")
                        .WithMany("Breakups")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PayrollMasters.Domain.Entities.PayHead", "PayHead")
                        .WithMany()
                        .HasForeignKey("PayHeadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entry");

                    b.Navigation("PayHead");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.PayrollVoucherEntry", b =>
                {
                    b.HasOne("PayrollMasters.Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PayrollMasters.Domain.Entities.PayrollVoucher", "Voucher")
                        .WithMany("Entries")
                        .HasForeignKey("VoucherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("PayHeadAssignments");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.EmployeeGroup", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.PayrollVoucher", b =>
                {
                    b.Navigation("Entries");
                });

            modelBuilder.Entity("PayrollMasters.Domain.Entities.PayrollVoucherEntry", b =>
                {
                    b.Navigation("Breakups");
                });
#pragma warning restore 612, 618
        }
    }
}
