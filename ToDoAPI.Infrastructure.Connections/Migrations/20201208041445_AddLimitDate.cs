using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoAPI.Infrastructure.Connections.Migrations
{
    public partial class AddLimitDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LimitDate",
                table: "todoitems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LimitDate",
                table: "todoitems");
        }
    }
}
