using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ESCoreMovies.Entities.Configurations
{
    public class MovieActorConfig : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {

            builder.HasKey(p => new { p.MovieId, p.ActorId });

        }
    }
}