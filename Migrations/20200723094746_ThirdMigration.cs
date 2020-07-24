using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevWebsCourseProjectApp.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "TimeStamp",
                table: "Addresses",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Persons",
                nullable: true,
                computedColumnSql: "[FirstName] + ' , ' + [Surname]");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonId",
                table: "Persons",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonId_FirstName",
                table: "Persons",
                columns: new[] { "PersonId", "FirstName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_PersonId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PersonId_FirstName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
