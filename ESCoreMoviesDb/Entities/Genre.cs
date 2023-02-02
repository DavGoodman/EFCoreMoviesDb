using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    //[Table(name: "GenresTbl", Schema = "movies")] // naming table
    public class Genre
    {
        public int Id { get; set; }
        //[StringLength(maximumLength:150)]
        [Required]
        //[Column("GenreName")] // naming column
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
