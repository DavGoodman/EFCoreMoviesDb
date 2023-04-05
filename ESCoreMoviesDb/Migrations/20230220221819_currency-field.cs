using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESCoreMoviesDb.Migrations
{
    /// <inheritdoc />
    public partial class currencyfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "CinemaHalls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 1,
                column: "Currency",
                value: "");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 2,
                column: "Currency",
                value: "");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 3,
                column: "Currency",
                value: "");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 4,
                column: "Currency",
                value: "");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 5,
                column: "Currency",
                value: "");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 6,
                column: "Currency",
                value: "");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 7,
                column: "Currency",
                value: "");

            migrationBuilder.UpdateData(
                table: "CinemaHalls",
                keyColumn: "Id",
                keyValue: 8,
                column: "Currency",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "CinemaHalls");
        }
    }
}
