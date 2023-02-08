using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ESCoreMoviesDb.Entities.Configurations
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Biography).HasColumnType("nvarchar(max)").IsRequired(false);

            //builder.Property(p => p.Name).HasField("_name");
        }

    }
}
