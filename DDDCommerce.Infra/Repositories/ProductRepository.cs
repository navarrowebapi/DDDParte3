using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDCommerce.Domain.Store.Entities;
using DDDCommerce.Domain.Store.Repositories;
using DDDCommerce.Infra.Contexts;

namespace DDDCommerce.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DDDCommerce_StoreDataContext _context;

        public ProductRepository(DDDCommerce_StoreDataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            return _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IList<Product> GetProducts(List<Guid> ids)
        {
            throw new NotImplementedException();
        }
    }
}
