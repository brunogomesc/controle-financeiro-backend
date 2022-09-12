using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Mappings
{
    public class TypeMap : IEntityTypeConfiguration<BLL.Models.Type>
    {
        public void Configure(EntityTypeBuilder<BLL.Models.Type> builder)
        {
            builder.HasKey(t => t.TypeId);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(20);
            builder.HasMany(t => t.Categories).WithOne(t => t.Type);

            builder.HasData(
                new BLL.Models.Type {
                    TypeId = 1,
                    Name = "Despesa"
                },
                new BLL.Models.Type
                {
                    TypeId = 2,
                    Name = "Ganhos"
                }
            );

            builder.ToTable("Types");

        }
    }
}
