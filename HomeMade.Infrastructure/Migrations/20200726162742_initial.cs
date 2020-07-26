using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeMade.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipeName = table.Column<string>(nullable: true),
                    RecipeClassification = table.Column<string>(nullable: true),
                    RecipeCost = table.Column<float>(nullable: true),
                    PortionCost = table.Column<float>(nullable: true),
                    RecipeStandardYield = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientName = table.Column<string>(nullable: true),
                    IngredientQuantity = table.Column<int>(nullable: false),
                    IngredientUnit = table.Column<string>(nullable: true),
                    IngredientEdibleYieldPercentage = table.Column<float>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "PortionCost", "RecipeClassification", "RecipeCost", "RecipeName", "RecipeStandardYield" },
                values: new object[] { 1, null, "Lunch", null, "Peanut Butter Banana Sandwiches", null });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IngredientEdibleYieldPercentage", "IngredientName", "IngredientQuantity", "IngredientUnit", "RecipeId" },
                values: new object[] { 1, 100f, "Bread", 2, "slices", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IngredientEdibleYieldPercentage", "IngredientName", "IngredientQuantity", "IngredientUnit", "RecipeId" },
                values: new object[] { 2, 100f, "Peanut Butter", 2, "ounces", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IngredientEdibleYieldPercentage", "IngredientName", "IngredientQuantity", "IngredientUnit", "RecipeId" },
                values: new object[] { 3, 66.67f, "Banana", 2, "ounces", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
