using Jantuscara.Domain;

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
                var result = _context.Customers.SingleOrDefault(x => x.Document.Equals(customer.Document));

                if (result != null) return result;

                _context.Customers.Add(customer);
                _context.SaveChanges();

                return customer;
            }
            catch (Exception) { throw; }
        }

        public Customer Update(Customer customer)
        {
            if (customer == null) return null;
            try
            {
                var result = _context.Customers.SingleOrDefault(x => x.Document.Equals(customer.Document));

                if (result == null) return null;

                customer.Id = result.Id;
                customer.Document = result.Document; // verificar se precisa
                _context.Entry(result).CurrentValues.SetValues(customer);
                _context.SaveChanges();

                return result;
            }
            catch (Exception) { throw; }
        }
    }
}
