using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sofis.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangesOnFamilyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_Child_ChildId",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                table: "Report");

            migrationBuilder.RenameTable(
                name: "Report",
                newName: "Reports");

            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "Family",
                newName: "Phone");

            migrationBuilder.RenameIndex(
                name: "IX_Report_ChildId",
                table: "Reports",
                newName: "IX_Reports_ChildId");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Family",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Child_ChildId",
                table: "Reports",
                column: "ChildId",
                principalTable: "Child",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Child_ChildId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Family");

            migrationBuilder.RenameTable(
                name: "Reports",
                newName: "Report");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Family",
                newName: "Contact");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ChildId",
                table: "Report",
                newName: "IX_Report_ChildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                table: "Report",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Child_ChildId",
                table: "Report",
                column: "ChildId",
                principalTable: "Child",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
