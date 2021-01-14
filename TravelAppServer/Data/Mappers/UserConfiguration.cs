using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TravelApp.Models;

namespace TravelAppServer.Data.Mappers
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Table name
            builder.ToTable("Users");

            //Primary Key
            builder.HasKey(b => b.UserId);

            //Properties
            builder.Property(b => b.UserName)
                   .IsRequired();

            builder.Property(b => b.Password)
                   .IsRequired();

            //Associations
            builder.HasMany(b => b.Travelplans)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
