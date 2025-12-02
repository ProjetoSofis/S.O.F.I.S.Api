using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sofis.Api.Migrations
{
    /// <inheritdoc />
    public partial class GuardianRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Child_Guardians_GuardianId",
                table: "Child");

            migrationBuilder.DropIndex(
                name: "IX_Child_GuardianId",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "GuardianId",
                table: "Child");

            migrationBuilder.AddColumn<Guid>(
                name: "ChildId",
                table: "Guardians",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Kinship",
                table: "Guardians",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "Kinship",
                table: "Guardians");

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
    }
}
