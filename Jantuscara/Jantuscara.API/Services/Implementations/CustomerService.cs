using Jantuscara.Domain;
using Jantuscara.Repository;

namespace Jantuscara.API
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerConverter _converter;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
            _converter = new CustomerConverter();
        }

        public CustomerResponseVO Create(CustomerVO customer)
        {
            var entity = _converter.Parse(customer);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }

        public CustomerResponseVO Update(CustomerVO customer)
        {
            var entity = _converter.Parse(customer);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }
    }
}
