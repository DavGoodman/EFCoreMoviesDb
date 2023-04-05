using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESCoreMoviesDb.Migrations
{
    /// <inheritdoc />
    public partial class viewMovieCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW dbo.MoviesWithCounts
as

SELECT Id, Title,
(SELECT COUNT(*) FROM GenreMovie WHERE MoviesId = movies.Id) AS AmountGenres,
(SELECT COUNT(DISTINCT MoviesId) FROM CinemaHallMovie
	INNER JOIN CinemaHalls
	ON CinemaHalls.id = CinemaHallMovie.CinemaHallsId
	WHERE MoviesId = movies.Id) AS AmountCinemas,
(SELECT COUNT(*) FROM MoviesActors WHERE MovieId = movies.Id) AS AmountActors
FROM Movies;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.MoviesWithCounts");
        }
    }
}
