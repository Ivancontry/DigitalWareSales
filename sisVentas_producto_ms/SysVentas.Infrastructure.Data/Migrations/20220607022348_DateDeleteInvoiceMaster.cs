using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SysVentas.Infrastructure.Data.Migrations
{
    public partial class DateDeleteInvoiceMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                schema: "SysSales",
                table: "InvoiceMaster");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCancel",
                schema: "SysSales",
                table: "InvoiceMaster",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCancel",
                schema: "SysSales",
                table: "InvoiceMaster",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "SysSales",
                table: "InvoiceMaster",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
