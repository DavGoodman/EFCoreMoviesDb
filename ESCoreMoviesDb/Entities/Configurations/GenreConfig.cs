using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ESCoreMovies.Entities.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.HasQueryFilter(g => !g.IsDeleted);
        }
    }
}
