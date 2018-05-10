using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UIdea.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Idea",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Members = table.Column<string>(nullable: true),
                    OwnerID = table.Column<string>(nullable: true),
                    RequiredMembers = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idea", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Idea");
        }
    }
}
