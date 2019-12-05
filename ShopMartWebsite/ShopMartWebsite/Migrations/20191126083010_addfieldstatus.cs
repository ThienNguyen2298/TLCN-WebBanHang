using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShopMartWebsite.Migrations
{
    public partial class addfieldstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "reply",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "comment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "category",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "status",
                table: "reply");

            migrationBuilder.DropColumn(
                name: "status",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "status",
                table: "category");

            migrationBuilder.DropColumn(
                name: "status",
                table: "AspNetUsers");

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
    }
}
