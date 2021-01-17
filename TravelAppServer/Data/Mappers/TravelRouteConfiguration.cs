using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.Models;

namespace TravelAppServer.Data.Mappers
{
    public class TravelRouteConfiguration : IEntityTypeConfiguration<TravelRoute>
    {
        public void Configure(EntityTypeBuilder<TravelRoute> builder)
        {
            //Table name
            builder.ToTable("TravelRoutes");

            //Primary Key
            builder.HasKey(b => b.TravelRouteId);

            //Properties
            builder.Property(b => b.Name)
                .IsRequired();

            //Associations
            builder.HasMany(b => b.Locations)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
