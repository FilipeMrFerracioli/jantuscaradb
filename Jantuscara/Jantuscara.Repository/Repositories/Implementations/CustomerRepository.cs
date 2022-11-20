using Jantuscara.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jantuscara.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MySqlDbContext _context;

        public CustomerRepository(MySqlDbContext context)
        {
            _context = context;
        }

        public Customer Create(Customer customer)
        {
            if (customer == null) return null;
            try
            {
                //var result = _context.Customers.SingleOrDefault(x => x.Document.Equals(customer.Document)); com LINQ
                var result = _context.Customers.FromSqlRaw($"SELECT * FROM customers WHERE document = {customer.Document}").FirstOrDefault();

                if (result != null) return result;

                //_context.Customers.Add(customer); com LINQ
                _context.Database.ExecuteSqlRaw(@"INSERT INTO customers (first_name, last_name, document)"
                                                + " VALUES ({0}, {1}, {2})", customer.FirstName, customer.LastName, customer.Document);
                _context.SaveChanges();

                return customer;
            }
            catch (Exception) { throw; }
        }
    }
}
