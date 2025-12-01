using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sofis.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddGuardianEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildFamily");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Family");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Family");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Family");

            migrationBuilder.DropColumn(
                name: "Kinship",
                table: "Family");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Family");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Family",
                newName: "SurName");

            migrationBuilder.AddColumn<string>(
                name: "AnoEscolar",
                table: "Child",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoEol",
                table: "Child",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Child",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "FamilyId",
                table: "Child",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UnidadeEscolar",
                table: "Child",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Guardians",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Kinship = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    FamilyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guardians_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_EmployeeId",
                table: "Reports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Child_FamilyId",
                table: "Child",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_FamilyId",
                table: "Guardians",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Child_Family_FamilyId",
                table: "Child",
                column: "FamilyId",
                principalTable: "Family",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Employees_EmployeeId",
                table: "Reports",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Child_Family_FamilyId",
                table: "Child");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Employees_EmployeeId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Guardians");

            migrationBuilder.DropIndex(
                name: "IX_Reports_EmployeeId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Child_FamilyId",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "AnoEscolar",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "CodigoEol",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "UnidadeEscolar",
                table: "Child");

            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Family",
                newName: "Phone");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Family",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Family",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Family",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kinship",
                table: "Family",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Family",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ChildFamily",
                columns: table => new
                {
                    FamilyMembersId = table.Column<Guid>(type: "uuid", nullable: false),
                    RelationedChildrenId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildFamily", x => new { x.FamilyMembersId, x.RelationedChildrenId });
                    table.ForeignKey(
                        name: "FK_ChildFamily_Child_RelationedChildrenId",
                        column: x => x.RelationedChildrenId,
                        principalTable: "Child",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildFamily_Family_FamilyMembersId",
                        column: x => x.FamilyMembersId,
                        principalTable: "Family",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildFamily_RelationedChildrenId",
                table: "ChildFamily",
                column: "RelationedChildrenId");
        }
    }
}
