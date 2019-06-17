using Microsoft.EntityFrameworkCore.Migrations;

namespace EVErything.Business.Migrations
{
    public partial class AddDummyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DummyName",
                table: "Accounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DummyName",
                table: "Accounts");
        }
    }
}
