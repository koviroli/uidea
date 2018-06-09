using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UIdea.Migrations.Issue
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ProjectID = table.Column<string>(nullable: true),
                    IssueType = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    RewardType = table.Column<int>(nullable: false),
                    Reward = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issue");
        }
    }
}
