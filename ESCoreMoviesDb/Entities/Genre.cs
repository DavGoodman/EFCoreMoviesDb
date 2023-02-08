using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    //[Table(name: "GenresTbl", Schema = "movies")] // naming table
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
