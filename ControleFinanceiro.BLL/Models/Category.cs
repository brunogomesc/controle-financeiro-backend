using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.BLL.Models
{
    public  class Category
    {

        public int CategoryId { get; set; } 

        public string? Name { get; set; }

        public string? Icon { get; set; }    

        public int TypeID { get; set; }

        public Type? Type { get; set; }

        public virtual ICollection<Expense>? Expenses { get; set;}

        public virtual ICollection<Gain>? Earnings { get; set; }

    }
}
