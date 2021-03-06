﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.Models;

namespace TravelAppServer.Data.Mappers
{
    public class TravelLocationConfiguration : IEntityTypeConfiguration<TravelLocation>
    {
        public void Configure(EntityTypeBuilder<TravelLocation> builder)
        {
            //Table name
            builder.ToTable("TravelLocations");

            //Primary Key
            builder.HasKey(b => b.TravelLocationId);

            //Properties
            builder.Property(b => b.Name)
                .IsRequired();
        }
    }
}
