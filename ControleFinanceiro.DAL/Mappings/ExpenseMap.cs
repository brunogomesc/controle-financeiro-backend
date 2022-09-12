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
    public class ExpenseMap : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(e => e.ExpenseId);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Value).IsRequired();
            builder.Property(e => e.Day).IsRequired();
            builder.Property(e => e.Year).IsRequired();
            builder.HasOne(e => e.Card).WithMany(e => e.Expenses).HasForeignKey(e => e.ExpenseId).IsRequired();
            builder.HasOne(e => e.Category).WithMany(e => e.Expenses).HasForeignKey(e => e.CategoryId).IsRequired();
            builder.HasOne(e => e.Month).WithMany(e => e.Expenses).HasForeignKey(e => e.MonthId).IsRequired();
            builder.HasOne(e => e.User).WithMany(e => e.Expenses).HasForeignKey(e => e.UserId).IsRequired();

            builder.ToTable("Expenses");
        }
    }
}
