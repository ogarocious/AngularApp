using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyFirstApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedRappers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Name", "TotalStars", "Username" },
                values: new object[,]
                {
                    { 1, "Jay-Z", 0, "jayz" },
                    { 2, "Kanye West", 0, "kanyewest" },
                    { 3, "Eminem", 0, "eminem" },
                    { 4, "Tupac Shakur", 0, "tupac" },
                    { 5, "The Notorious B.I.G.", 0, "biggie" },
                    { 6, "Drake", 0, "drake" },
                    { 7, "Kendrick Lamar", 0, "kendricklamar" },
                    { 8, "Lil Wayne", 0, "lilwayne" },
                    { 9, "Nicki Minaj", 0, "nickiminaj" },
                    { 10, "Snoop Dogg", 0, "snoopdogg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
