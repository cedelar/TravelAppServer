using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;

namespace TravelAppServer.Data.Mappers
{
    public class TravelItemConfiguration : IEntityTypeConfiguration<TravelItem>
    {
        public void Configure(EntityTypeBuilder<TravelItem> builder)
        {
            //Table name
            builder.ToTable("TravelItems");

            //Primary Key
            builder.HasKey(b => b.TravelItemId);

            //Properties
            builder.Property(b => b.Name)
                .IsRequired();

            builder.Property(b => b.IsChecked)
                .IsRequired();

            builder.Property(b => b.Amount)
                   .IsRequired();
        }
    }
}
