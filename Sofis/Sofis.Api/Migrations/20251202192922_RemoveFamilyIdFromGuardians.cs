using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sofis.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFamilyIdFromGuardians : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guardians_Family_FamilyId",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "Guardians");

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyId",
                table: "Guardians",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "ChildGuardian",
                columns: table => new
                {
                    ChildrenId = table.Column<Guid>(type: "uuid", nullable: false),
                    GuardiansId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildGuardian", x => new { x.ChildrenId, x.GuardiansId });
                    table.ForeignKey(
                        name: "FK_ChildGuardian_Child_ChildrenId",
                        column: x => x.ChildrenId,
                        principalTable: "Child",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildGuardian_Guardians_GuardiansId",
                        column: x => x.GuardiansId,
                        principalTable: "Guardians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildGuardian_GuardiansId",
                table: "ChildGuardian",
                column: "GuardiansId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guardians_Family_FamilyId",
                table: "Guardians",
                column: "FamilyId",
                principalTable: "Family",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guardians_Family_FamilyId",
                table: "Guardians");

            migrationBuilder.DropTable(
                name: "ChildGuardian");

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyId",
                table: "Guardians",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChildId",
                table: "Guardians",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Guardians_Family_FamilyId",
                table: "Guardians",
                column: "FamilyId",
                principalTable: "Family",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
