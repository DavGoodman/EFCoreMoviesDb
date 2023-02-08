using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ESCoreMovies.Entities.Configurations
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {

            builder.Property(p => p.Title).HasMaxLength(250).IsRequired();
            builder.Property(p => p.PosterUrl).HasMaxLength(500).IsRequired(false).IsUnicode(false);

        }
    }
}