using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CentricExpress.DataAccess.Migrations
{
    public partial class AddCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "Price_Currency",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price_Value",
                table: "Item",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price_Currency",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Price_Value",
                table: "Item");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Item",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
