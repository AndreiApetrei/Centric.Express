using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CentricExpress.DataAccess.Migrations
{
    public partial class AddDiscountOnOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discount_Currency",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount_Value",
                table: "Order",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount_Currency",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Discount_Value",
                table: "Order");
        }
    }
}
