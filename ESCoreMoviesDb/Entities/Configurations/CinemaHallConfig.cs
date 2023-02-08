using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ESCoreMoviesDb.Entities.Configurations
{
    public class CinemaHallConfig : IEntityTypeConfiguration<CinemaHall>
    {
        public void Configure(EntityTypeBuilder<CinemaHall> builder)
        {
            builder.Property(p => p.Cost).HasPrecision(9, 2);
            builder.Property(p => p.CinemaHallType).HasDefaultValue(CinemaHallType.TwoDimensions);
        }

    }
}
