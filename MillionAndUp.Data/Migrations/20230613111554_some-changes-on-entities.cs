using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MillionAndUp.Data.Migrations
{
    public partial class somechangesonentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTraces_Properties_PropertyId",
                table: "PropertyTraces");

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "PropertyTraces",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "File",
                table: "PropertyImages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTraces_Properties_PropertyId",
                table: "PropertyTraces",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTraces_Properties_PropertyId",
                table: "PropertyTraces");

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "PropertyTraces",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "File",
                table: "PropertyImages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTraces_Properties_PropertyId",
                table: "PropertyTraces",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }
    }
}
