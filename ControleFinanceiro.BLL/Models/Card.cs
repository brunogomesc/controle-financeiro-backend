using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.BLL.Models
{
    public class Card
    {

        public int? CardId { get; set; }

        public string? Name { get; set; }

        public string? Flag { get; set; }

        public string? Number { get; set; }

        public double? Limit { get; set; }

        public string? UserId { get; set; }

        public User? User { get; set; }

        public virtual ICollection<Expense>? Expenses { get; set; }

    }
}
