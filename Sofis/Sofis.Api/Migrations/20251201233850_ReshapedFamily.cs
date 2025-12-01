using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sofis.Api.Migrations
{
    /// <inheritdoc />
    public partial class ReshapedFamily : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "Kinship",
                table: "Guardians");

            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Family",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Family",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "GuardianId",
                table: "Child",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Child_GuardianId",
                table: "Child",
                column: "GuardianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Child_Guardians_GuardianId",
                table: "Child",
                column: "GuardianId",
                principalTable: "Guardians",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Child_Guardians_GuardianId",
                table: "Child");

            migrationBuilder.DropIndex(
                name: "IX_Child_GuardianId",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Family");

            migrationBuilder.DropColumn(
                name: "GuardianId",
                table: "Child");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Family",
                newName: "SurName");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Guardians",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kinship",
                table: "Guardians",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
