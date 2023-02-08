using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESCoreMoviesDb.Migrations
{
    /// <inheritdoc />
    public partial class genresSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Genres",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Tom Holland");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Samuel L. Jackson");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Robert Downey Jr.");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Chris Evans");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Dwayne Johnson");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Auli'i Cravalho");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Scarlett Johansson");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Keanu Reeves");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Genres");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "TSystem.Char[] HSystem.Char[]");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "SSystem.Char[] LSystem.Char[] JSystem.Char[]");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "RSystem.Char[] DSystem.Char[] JSystem.Char[]");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "CSystem.Char[] ESystem.Char[]");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "DSystem.Char[] JSystem.Char[]");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "ASystem.Char[] CSystem.Char[]");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "SSystem.Char[] JSystem.Char[]");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "KSystem.Char[] RSystem.Char[]");
        }
    }
}
