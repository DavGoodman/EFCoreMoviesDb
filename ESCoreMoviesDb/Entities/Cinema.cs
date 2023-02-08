using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace EFCoreMovies.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Precision(precision:9, scale:2)]
        public Point Location { get; set; }

        // one-to-one relationship, adds foreign key TO CinemaOffer, not this entity, navigation property
        public CinemaOffer CinemaOffer { get; set; }

        // one to many relationship, column values do not have to be unique
        public List<CinemaHall> CinemaHalls { get; set; }

    }   
}
