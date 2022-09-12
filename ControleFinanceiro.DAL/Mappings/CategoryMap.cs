using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.DAL.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Icon).IsRequired().HasMaxLength(15);
            builder.HasOne(c => c.Type).WithMany(c => c.Categories).HasForeignKey(c => c.TypeID).IsRequired();
            builder.HasMany(c => c.Earnings).WithOne(c => c.Category);
            builder.HasMany(c => c.Expenses).WithOne(c => c.Category);

            builder.ToTable("Categories");
        }
    }
}
