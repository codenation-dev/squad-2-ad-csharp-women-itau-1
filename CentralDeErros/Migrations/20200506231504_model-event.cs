using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErros.Migrations
{
    public partial class modelevent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "archived",
                table: "event",
                nullable: false,
                oldClrType: typeof(byte));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "archived",
                table: "event",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
