using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sofis.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangesOnEmplooyee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TwoFactorSecret",
                table: "Employees",
                newName: "TwoEmailCode");

            migrationBuilder.AddColumn<DateTime>(
                name: "TwoFactorEmailCodeExpiration",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TwoFactorEmailCodeExpiration",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "TwoEmailCode",
                table: "Employees",
                newName: "TwoFactorSecret");
        }
    }
}
