using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVErything.Business.Migrations
{
    public partial class AddESIDataCache : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESIDataCaches",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CharacterID = table.Column<string>(nullable: false),
                    ESISource = table.Column<string>(nullable: false),
                    ESIRoute = table.Column<string>(nullable: false),
                    LastUpdateTimestamp = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(maxLength: 2147483647, nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_ESIDataCaches_CharacterID",
                table: "ESIDataCaches",
                column: "CharacterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ESIDataCaches");
        }
    }
}
