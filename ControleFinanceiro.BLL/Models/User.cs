using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.BLL.Models
{
    public class User : IdentityUser<string>
    {

        public string? CPF { get; set; }

        public string? Profession { get; set; }

        public byte[]? Photo { get; set; }

        public virtual ICollection<Card>? Cards { get; set; }

        public virtual ICollection<Gain>? Earnings { get; set; }

        public virtual ICollection<Expense>? Expenses { get; set; }

    }
}
