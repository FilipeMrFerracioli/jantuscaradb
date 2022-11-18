using Jantuscara.Domain;

namespace Jantuscara.API
{
    public interface ICustomerService
    {
        public CustomerResponseVO Create(CustomerVO customer);
        public CustomerResponseVO Update(CustomerVO customer);
    }
}
