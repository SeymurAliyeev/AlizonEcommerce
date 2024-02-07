using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAddresses_Users_UserId",
                table: "DeliveryAddresses");

            migrationBuilder.AddColumn<bool>(
                name: "Session",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "DeliveryAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAddresses_Users_UserId",
                table: "DeliveryAddresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAddresses_Users_UserId",
                table: "DeliveryAddresses");

            migrationBuilder.DropColumn(
                name: "Session",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "DeliveryAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAddresses_Users_UserId",
                table: "DeliveryAddresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
