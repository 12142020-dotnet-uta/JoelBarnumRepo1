using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P0_JoelBarnum.Migrations
{
    public partial class _3rdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_orderHistory_OrderId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_OrderId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "products");

            migrationBuilder.CreateTable(
                name: "purchasedProducts",
                columns: table => new
                {
                    PurchaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchasedProducts", x => x.PurchaseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchasedProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_OrderId",
                table: "products",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_orderHistory_OrderId",
                table: "products",
                column: "OrderId",
                principalTable: "orderHistory",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
