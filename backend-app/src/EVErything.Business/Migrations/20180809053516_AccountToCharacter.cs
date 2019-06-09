using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVErything.Business.Migrations
{
    public partial class AccountToCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Accounts_AccountID",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "ExpiresIn",
                table: "Tokens",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountID",
                table: "Characters",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Accounts_AccountID",
                table: "Characters",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Accounts_AccountID",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "ExpiresIn",
                table: "Tokens",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountID",
                table: "Characters",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Accounts_AccountID",
                table: "Characters",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
