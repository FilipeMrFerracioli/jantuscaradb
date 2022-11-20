using Jantuscara.Domain;

namespace Jantuscara.Repository
{
    public interface ICustomerRepository
    {
        public Customer Create(Customer customer);
    }
}
