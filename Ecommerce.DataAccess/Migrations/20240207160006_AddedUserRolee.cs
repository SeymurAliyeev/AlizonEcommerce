using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserRolee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Role",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
