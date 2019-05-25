using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDCommerce.Infra.Contexts;

namespace DDDCommerce.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly DDDCommerce_StoreDataContext _context;

        public Uow(DDDCommerce_StoreDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            //Não necessita implementar, pois o próprio EF cuida da requisição e deixa morrer caso não
            //seja dado o commit.
        }
    }
}
