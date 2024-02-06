using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreatedAllPropertiesofTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatTime",
                table: "Wallets");

            migrationBuilder.RenameColumn(
                name: "ExpireDate",
                table: "Wallets",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatTime",
                table: "Users",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatTime",
                table: "Products",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatTime",
                table: "ProductInvoices",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatTime",
                table: "Invoices",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatTime",
                table: "Discounts",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatTime",
                table: "DeliveryAddresses",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatTime",
                table: "Categories",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatTime",
                table: "Brands",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatTime",
                table: "Baskets",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "CreatTime",
                table: "BasketProducts",
                newName: "CreateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Wallets",
                newName: "ExpireDate");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Users",
                newName: "CreatTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Products",
                newName: "CreatTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "ProductInvoices",
                newName: "CreatTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Invoices",
                newName: "CreatTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Discounts",
                newName: "CreatTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "DeliveryAddresses",
                newName: "CreatTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Categories",
                newName: "CreatTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Brands",
                newName: "CreatTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Baskets",
                newName: "CreatTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "BasketProducts",
                newName: "CreatTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatTime",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
