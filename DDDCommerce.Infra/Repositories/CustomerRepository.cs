using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDCommerce.Domain.Store.Entities;
using DDDCommerce.Domain.Store.Repositories;
using DDDCommerce.Infra.Contexts;

namespace DDDCommerce.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DDDCommerce_StoreDataContext _context;

        public CustomerRepository(DDDCommerce_StoreDataContext context)
        {
            _context = context;
        }

        public Customer GetById(Guid id)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);
            //AsNoTracking não faz Cache dos dados da entidade no EF, não fica fazendo histórico 
            //das mudanças da entidade, somente faz a leitura e pronto, performance.
        }

        public void Save(Customer customer)
        {
            if (customer.Valid)
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public Task<List<Customer>> GetCustomers()
        {

            return _context.Customers.ToListAsync();
        }
    }
}
