using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShopMartWebsite.Migrations
{
    public partial class deletecascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_product_productId",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_product_category_categoryId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_reply_comment_commentId",
                table: "reply");

            migrationBuilder.AddColumn<string>(
                name: "note",
                table: "order",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Product",
                table: "comment",
                column: "productId",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category",
                table: "product",
                column: "categoryId",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Comment",
                table: "reply",
                column: "commentId",
                principalTable: "comment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Product",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Comment",
                table: "reply");

            migrationBuilder.DropColumn(
                name: "note",
                table: "order");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_product_productId",
                table: "comment",
                column: "productId",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_category_categoryId",
                table: "product",
                column: "categoryId",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reply_comment_commentId",
                table: "reply",
                column: "commentId",
                principalTable: "comment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
