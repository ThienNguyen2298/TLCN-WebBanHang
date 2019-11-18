using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShopMartWebsite.Migrations
{
    public partial class updatekeyuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_AspNetUsers_userId1",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_order_AspNetUsers_userId1",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_reply_AspNetUsers_userId1",
                table: "reply");

            migrationBuilder.DropIndex(
                name: "IX_reply_userId1",
                table: "reply");

            migrationBuilder.DropIndex(
                name: "IX_order_userId1",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_comment_userId1",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "userId1",
                table: "reply");

            migrationBuilder.DropColumn(
                name: "userId1",
                table: "order");

            migrationBuilder.DropColumn(
                name: "userId1",
                table: "comment");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "reply",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "order",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "comment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_reply_userId",
                table: "reply",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_order_userId",
                table: "order",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_userId",
                table: "comment",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_AspNetUsers_userId",
                table: "comment",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_order_AspNetUsers_userId",
                table: "order",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reply_AspNetUsers_userId",
                table: "reply",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_AspNetUsers_userId",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_order_AspNetUsers_userId",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_reply_AspNetUsers_userId",
                table: "reply");

            migrationBuilder.DropIndex(
                name: "IX_reply_userId",
                table: "reply");

            migrationBuilder.DropIndex(
                name: "IX_order_userId",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_comment_userId",
                table: "comment");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "reply",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId1",
                table: "reply",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "order",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId1",
                table: "order",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "comment",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId1",
                table: "comment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reply_userId1",
                table: "reply",
                column: "userId1");

            migrationBuilder.CreateIndex(
                name: "IX_order_userId1",
                table: "order",
                column: "userId1");

            migrationBuilder.CreateIndex(
                name: "IX_comment_userId1",
                table: "comment",
                column: "userId1");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_AspNetUsers_userId1",
                table: "comment",
                column: "userId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_order_AspNetUsers_userId1",
                table: "order",
                column: "userId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reply_AspNetUsers_userId1",
                table: "reply",
                column: "userId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
