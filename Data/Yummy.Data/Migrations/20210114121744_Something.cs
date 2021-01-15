namespace Yummy.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Something : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "RecipeIngredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "RecipeIngredients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RecipeIngredients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "RecipeIngredients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IsDeleted",
                table: "RecipeIngredients",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredients_IsDeleted",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "RecipeIngredients");
        }
    }
}
