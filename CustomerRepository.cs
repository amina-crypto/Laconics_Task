using Laconics_Task.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Laconics_Task
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }


        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public Customer Get(int id)
        {
            // Use Find method to take advantage of Entity Framework's change tracking
            return _context.Customers.Find(id);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var customerToDelete = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerToDelete != null)
            {
                _context.Customers.Remove(customerToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Customer> ListAll()
        {
            return _context.Customers.ToList();
        }

    
    }
}
