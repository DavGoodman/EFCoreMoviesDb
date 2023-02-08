namespace EFCoreMovies.Entities
{
    public class CinemaHall
    {
        public int Id { get; set; }
        public CinemaHallType CinemaHallType { get; set; }
        public decimal Cost { get; set; }
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; } // navigation property, optional
        public List<Movie> Movies { get; set; }
    }
}
