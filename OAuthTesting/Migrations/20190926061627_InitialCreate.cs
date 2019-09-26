using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OAuthTesting.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Username = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
