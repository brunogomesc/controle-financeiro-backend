using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL
{
    public class Context : IdentityDbContext<User, Function, string>
    {

        public DbSet<Card>? Cards { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Expense>? Expenses { get; set; }

        public DbSet<Function>? Functions { get; set; }

        public DbSet<Gain>? Earnings { get; set; }

        public DbSet<Month>? Months { get; set; }

        public DbSet<BLL.Models.Type> Types { get; set; }

        public DbSet<User>? User { get; set; }

        public Context(DbContextOptions<Context> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CardMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new ExpenseMap());
            builder.ApplyConfiguration(new FunctionMap());
            builder.ApplyConfiguration(new GainMap());
            builder.ApplyConfiguration(new MonthMap());
            builder.ApplyConfiguration(new TypeMap());
            builder.ApplyConfiguration(new UserMap());
        }

    }
}
