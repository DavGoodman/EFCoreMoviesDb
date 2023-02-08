using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ESCoreMoviesDb.Entities.Configurations
{
    public class CinemaOfferConfig : IEntityTypeConfiguration<CinemaOffer>
    {
        public void Configure(EntityTypeBuilder<CinemaOffer> builder)
        {
            builder.Property(p => p.DiscountPercentage).HasPrecision(5, 2);
        }
    }
}