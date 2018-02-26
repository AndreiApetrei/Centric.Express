using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CentricExpress.DataAccess.Migrations
{
    public partial class AddCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Item_ItemId",
                table: "OrderLine");

            migrationBuilder.DropIndex(
                name: "IX_OrderLine_ItemId",
                table: "OrderLine");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderLine");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "Price_Currency",
                table: "OrderLine",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price_Value",
                table: "OrderLine",
                nullable: false,
                defaultValue: 0m);

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
                table: "OrderLine");

            migrationBuilder.DropColumn(
                name: "Price_Value",
                table: "OrderLine");

            migrationBuilder.DropColumn(
                name: "Price_Currency",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Price_Value",
                table: "Item");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "OrderLine",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Item",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_ItemId",
                table: "OrderLine",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Item_ItemId",
                table: "OrderLine",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
