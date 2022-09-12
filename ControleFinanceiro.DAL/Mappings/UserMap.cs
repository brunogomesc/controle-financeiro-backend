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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.CPF).IsRequired().HasMaxLength(20);
            builder.HasIndex(u => u.CPF).IsUnique();
            builder.Property(u => u.Profession).IsRequired().HasMaxLength(30);
            builder.HasMany(u => u.Cards).WithOne(u => u.User).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.Earnings).WithOne(u => u.User).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Users");
        }
    }
}
