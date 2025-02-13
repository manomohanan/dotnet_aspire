using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cart.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateCartDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id");
        }
    }
}
