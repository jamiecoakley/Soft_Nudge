using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Soft_Nudge.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seeded_User_Data_for_jamietest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Action", "Description", "OwnerId" },
                values: new object[,]
                {
                    { 1, "Make Your Bed!", "No need for nurse's corners, just straighten it up.", "5de245d3-d105-4132-bff4-4af80afeb76f" },
                    { 2, "Wash Your Face", "Don't forget to moisturize, too!", "5de245d3-d105-4132-bff4-4af80afeb76f" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
