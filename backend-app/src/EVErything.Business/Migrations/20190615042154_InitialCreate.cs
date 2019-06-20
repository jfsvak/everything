using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVErything.Business.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<byte[]>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CharacterSetID = table.Column<byte[]>(nullable: false),
                    AccountID = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Characters_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSets",
                columns: table => new
                {
                    ID = table.Column<byte[]>(nullable: false),
                    MainCharacterID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CharacterSets_Characters_MainCharacterID",
                        column: x => x.MainCharacterID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ESIDataCaches",
                columns: table => new
                {
                    ID = table.Column<byte[]>(nullable: false),
                    CharacterID = table.Column<string>(nullable: false),
                    ESISource = table.Column<string>(nullable: false),
                    ESIRoute = table.Column<string>(nullable: false),
                    LastUpdateTimestamp = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESIDataCaches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ESIDataCaches_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    CharacterID = table.Column<string>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: false),
                    AccessToken = table.Column<string>(nullable: false),
                    TokenType = table.Column<string>(nullable: false),
                    ExpiresIn = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.CharacterID);
                    table.ForeignKey(
                        name: "FK_Tokens_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AccountID",
                table: "Characters",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterSetID",
                table: "Characters",
                column: "CharacterSetID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSets_MainCharacterID",
                table: "CharacterSets",
                column: "MainCharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_ESIDataCaches_CharacterID",
                table: "ESIDataCaches",
                column: "CharacterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_CharacterSets_CharacterSetID",
                table: "Characters",
                column: "CharacterSetID",
                principalTable: "CharacterSets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Accounts_AccountID",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_CharacterSets_CharacterSetID",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "ESIDataCaches");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CharacterSets");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
