using Microsoft.EntityFrameworkCore.Migrations;

namespace movie_collection.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "MovieAdds",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    Lent_To = table.Column<string>(nullable: true),
                    Note = table.Column<string>(maxLength: 25, nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieAdds", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_MovieAdds_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Comedy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Romantic-Comedy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Animation" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Drama" });

            migrationBuilder.InsertData(
                table: "MovieAdds",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edited", "Lent_To", "Note", "Rating", "Title" },
                values: new object[] { 1, 1, "Rawson Thurber", true, "Connor Meadows", "This movie has been watched many a times in Newport Hills", "PG-13", "Dodgeball" });

            migrationBuilder.InsertData(
                table: "MovieAdds",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edited", "Lent_To", "Note", "Rating", "Title" },
                values: new object[] { 2, 2, "Jon M. Chu", false, null, null, "PG-13", "Crazy Rich Asians" });

            migrationBuilder.InsertData(
                table: "MovieAdds",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edited", "Lent_To", "Note", "Rating", "Title" },
                values: new object[] { 3, 3, "Jon M. Chu", false, null, null, "PG", "Mulan" });

            migrationBuilder.CreateIndex(
                name: "IX_MovieAdds_CategoryID",
                table: "MovieAdds",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieAdds");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
