using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration
{
    public class DutyConfiguration : IEntityTypeConfiguration<Duty>
    {
        public void Configure(EntityTypeBuilder<Duty> builder)
        {
            builder.ToTable("Duties").HasKey(t => t.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.UserId).HasColumnName("UserId");
            builder.Property(b => b.Title).HasColumnName("Title");
            builder.Property(b => b.Description).HasColumnName("Description");
            builder.Property(b => b.Status)
                   .HasColumnName("Status")
                   .HasConversion<int>();

            builder.HasOne(b => b.User)
                .WithMany(u => u.Duties)
                .HasForeignKey(b => b.UserId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
