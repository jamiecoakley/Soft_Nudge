using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soft_Nudge.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changed_note_entity_and_removed_note_from_todo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_ToDos_ToDoId",
                table: "Notes");

            migrationBuilder.AlterColumn<int>(
                name: "ToDoId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_ToDos_ToDoId",
                table: "Notes",
                column: "ToDoId",
                principalTable: "ToDos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_ToDos_ToDoId",
                table: "Notes");

            migrationBuilder.AlterColumn<int>(
                name: "ToDoId",
                table: "Notes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_ToDos_ToDoId",
                table: "Notes",
                column: "ToDoId",
                principalTable: "ToDos",
                principalColumn: "Id");
        }
    }
}
