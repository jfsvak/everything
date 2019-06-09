using Microsoft.EntityFrameworkCore.Migrations;

namespace EVErything.Business.Migrations
{
    public partial class AddMainCharID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainCharacterID",
                table: "CharacterSets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSets_MainCharacterID",
                table: "CharacterSets",
                column: "MainCharacterID");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSets_Characters_MainCharacterID",
                table: "CharacterSets",
                column: "MainCharacterID",
                principalTable: "Characters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSets_Characters_MainCharacterID",
                table: "CharacterSets");

            migrationBuilder.DropIndex(
                name: "IX_CharacterSets_MainCharacterID",
                table: "CharacterSets");

            migrationBuilder.DropColumn(
                name: "MainCharacterID",
                table: "CharacterSets");
        }
    }
}
