using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.BLL.Models
{
    public  class Month
    {

        public int MonthId { get; set; }    

        public string? Name { get; set; }

        public virtual ICollection<Gain>? Earnings { get; set; }

        public virtual ICollection<Expense>? Expenses { get; set; }

    }
}
