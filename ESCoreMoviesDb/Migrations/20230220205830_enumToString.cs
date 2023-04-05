using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESCoreMoviesDb.Migrations
{
    /// <inheritdoc />
    public partial class enumToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CinemaHallType",
                table: "CinemaHalls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "TwoDimensions",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CinemaHallType",
                value: "TwoDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CinemaHallType",
                value: "ThreeDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CinemaHallType",
                value: "TwoDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CinemaHallType",
                value: "ThreeDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CinemaHallType",
                value: "TwoDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CinemaHallType",
                value: "ThreeDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CinemaHallType",
                value: "CXC");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CinemaHallType",
                value: "TwoDimensions");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true,
                filter: "IsDeleted = 'false'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Genres_Name",
                table: "Genres");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaHallType",
                table: "CinemaHalls",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "TwoDimensions");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CinemaHallType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CinemaHallType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CinemaHallType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CinemaHallType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CinemaHallType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CinemaHallType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 7,
                column: "CinemaHallType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 8,
                column: "CinemaHallType",
                value: 1);
        }
    }
}
