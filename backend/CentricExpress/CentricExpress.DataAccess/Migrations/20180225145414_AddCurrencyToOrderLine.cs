using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CentricExpress.DataAccess.Migrations
{
    public partial class AddCurrencyToOrderLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderLine",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "Price_Currency",
                table: "OrderLine",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price_Currency",
                table: "OrderLine");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "OrderLine",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
