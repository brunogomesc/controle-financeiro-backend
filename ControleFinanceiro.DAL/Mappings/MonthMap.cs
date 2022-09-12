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
    public class MonthMap : IEntityTypeConfiguration<Month>
    {
        public void Configure(EntityTypeBuilder<Month> builder)
        {
            builder.HasKey(m => m.MonthId);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(20);
            builder.HasIndex(m => m.Name).IsUnique();
            builder.HasMany(m => m.Expenses).WithOne(m => m.Month);
            builder.HasMany(m => m.Earnings).WithOne(m => m.Month);

            builder.HasData(
                new Month
                { 
                    MonthId = 1,
                    Name = "Janeiro"
                },
                new Month
                {
                    MonthId = 2,
                    Name = "Fevereiro"
                },
                new Month
                {
                    MonthId = 3,
                    Name = "Março"
                },
                new Month
                {
                    MonthId = 4,
                    Name = "Abril"
                },
                new Month
                {
                    MonthId = 5,
                    Name = "Maio"
                },
                new Month
                {
                    MonthId = 6,
                    Name = "Junho"
                },
                new Month
                {
                    MonthId = 7,
                    Name = "Julho"
                },
                new Month
                {
                    MonthId = 8,
                    Name = "Agosto"
                },
                new Month
                {
                    MonthId = 9,
                    Name = "Setembro"
                },
                new Month
                {
                    MonthId = 10,
                    Name = "Outubro"
                },
                new Month
                {
                    MonthId = 11,
                    Name = "Novembro"
                },
                new Month
                {
                    MonthId = 12,
                    Name = "Dezembro"
                }
            );

            builder.ToTable("Months");
        }
    }
}
