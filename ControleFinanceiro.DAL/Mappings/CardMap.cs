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
    public class CardMap : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.CardId);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.Name).IsUnique();
            builder.Property(c => c.Flag).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Number).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.Number).IsUnique();
            builder.Property(c => c.Limit).IsRequired();
            builder.HasOne(c => c.User).WithMany(c => c.Cards).HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Expenses).WithOne(c => c.Card);

            builder.ToTable("Cards");
        }
    }
}
