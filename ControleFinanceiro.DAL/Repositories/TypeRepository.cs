using ControleFinanceiro.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repositories
{
    public class TypeRepository : GenericRepository<BLL.Models.Type>, ITypeRepository
    {

        public TypeRepository(Context context) : base(context)
        {

        }

    }
}
