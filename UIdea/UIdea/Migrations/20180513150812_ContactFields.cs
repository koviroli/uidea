using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UIdea.Migrations
{
    public partial class ContactFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Idea",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RequiredMembers",
                table: "Idea",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Idea",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailContact",
                table: "Idea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookContact",
                table: "Idea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GitHubContact",
                table: "Idea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramContact",
                table: "Idea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedinContact",
                table: "Idea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherContact",
                table: "Idea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterContact",
                table: "Idea",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailContact",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "FacebookContact",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "GitHubContact",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "InstagramContact",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "LinkedinContact",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "OtherContact",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "TwitterContact",
                table: "Idea");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Idea",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "RequiredMembers",
                table: "Idea",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Idea",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2000);
        }
    }
}
