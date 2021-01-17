using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.Models;

namespace TravelAppServer.Data.Mappers
{
    public class TravelPlanConfiguration : IEntityTypeConfiguration<TravelPlan>
    {
        public void Configure(EntityTypeBuilder<TravelPlan> builder)
        {
            //Table name
            builder.ToTable("TravelPlans");

            //Primary Key
            builder.HasKey(b => b.TravelPlanId);

            //Properties
            builder.Property(b => b.Name)
                .IsRequired();

            //Associations
            builder.HasMany(b => b.ItemList)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.TaskList)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.RouteList)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
