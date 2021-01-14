using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;

namespace TravelAppServer.Data.Mappers
{
    public class TravelTaskConfiguration : IEntityTypeConfiguration<TravelTask>
    {
        public void Configure(EntityTypeBuilder<TravelTask> builder)
        {
            //Table name
            builder.ToTable("TravelTasks");

            //Primary Key
            builder.HasKey(b => b.TravelTaskId);

            //Properties
            builder.Property(b => b.Name)
                .IsRequired();          
        }
    }
}
