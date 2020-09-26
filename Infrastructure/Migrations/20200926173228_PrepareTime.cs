using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class PrepareTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeToPrepare",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderCompleted",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitTimeToPrepare",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeToPrepare",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderCompleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UnitTimeToPrepare",
                table: "OrderDetails");
        }
    }
}
