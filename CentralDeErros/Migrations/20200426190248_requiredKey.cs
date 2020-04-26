using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralDeErros.Migrations
{
    public partial class requiredKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    level = table.Column<string>(maxLength: 45, nullable: false),
                    description = table.Column<string>(maxLength: 250, nullable: false),
                    origin = table.Column<string>(maxLength: 250, nullable: false),
                    data = table.Column<DateTime>(nullable: false),
                    log = table.Column<string>(maxLength: 4000, nullable: false),
                    environment = table.Column<string>(maxLength: 45, nullable: false),
                    archived = table.Column<byte>(nullable: false),
                    logId = table.Column<string>(maxLength: 45, nullable: false),
                    title = table.Column<string>(maxLength: 45, nullable: false),
                    collectedBy = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Login = table.Column<string>(maxLength: 45, nullable: false),
                    Password = table.Column<string>(maxLength: 45, nullable: false),
                    Created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
