namespace Yummy.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Mor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "RecipeIngredients",
                newName: "IngredientQuantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IngredientQuantity",
                table: "RecipeIngredients",
                newName: "Quantity");
        }
    }
}
