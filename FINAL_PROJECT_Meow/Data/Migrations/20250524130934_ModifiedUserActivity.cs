using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FINAL_PROJECT_Meow.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedUserActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketCategories_AspNetUsers_CreatedById",
                table: "TicketCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketCategories_AspNetUsers_ModifiedById",
                table: "TicketCategories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "TicketCategories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "TicketCategories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCategories_AspNetUsers_CreatedById",
                table: "TicketCategories",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCategories_AspNetUsers_ModifiedById",
                table: "TicketCategories",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketCategories_AspNetUsers_CreatedById",
                table: "TicketCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketCategories_AspNetUsers_ModifiedById",
                table: "TicketCategories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "TicketCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "TicketCategories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCategories_AspNetUsers_CreatedById",
                table: "TicketCategories",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCategories_AspNetUsers_ModifiedById",
                table: "TicketCategories",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
