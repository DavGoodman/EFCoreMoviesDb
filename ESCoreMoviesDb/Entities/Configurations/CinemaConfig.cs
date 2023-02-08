using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ESCoreMoviesDb.Entities.Configurations
{
    public class CinemaConfig : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {

            builder.Property(p => p.Name).IsRequired();
        }

    }
}
