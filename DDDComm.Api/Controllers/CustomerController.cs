using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDCommerce.Domain.Store.Entities;
using DDDCommerce.Domain.Store.Repositories;
using DDDCommerce.Infra.Contexts;
using DDDCommerce.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DDDComm.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }


        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return await _repository.GetCustomers();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            try
            {
                _repository.Save(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }
            
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
