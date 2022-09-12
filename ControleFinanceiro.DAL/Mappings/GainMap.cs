using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Mappings
{
    public class GainMap : IEntityTypeConfiguration<Gain>
    {
        public void Configure(EntityTypeBuilder<Gain> builder)
        {
            builder.HasKey(g => g.GainId);
            builder.Property(g => g.Description).IsRequired().HasMaxLength(50);
            builder.Property(g => g.Value).IsRequired();
            builder.Property(g => g.Day).IsRequired();
            builder.Property(g => g.Year).IsRequired();
            builder.HasOne(g => g.Category).WithMany(g => g.Earnings).HasForeignKey(g => g.CategoryId).IsRequired();
            builder.HasOne(g => g.Month).WithMany(g => g.Earnings).HasForeignKey(g => g.MonthId).IsRequired();
            builder.HasOne(g => g.User).WithMany(g => g.Earnings).HasForeignKey( g => g.UserId).IsRequired();

            builder.ToTable("Earnings");
        }
    }
}
