namespace Jantuscara.Domain
{
    public class CustomerConverter :
        IParser<CustomerVO, Customer>,
        IParser<Customer, CustomerResponseVO>,
        IParser<CustomerResponseVO, CustomerVO>
    {
        public Customer Parse(CustomerVO origin)
        {
            if (origin == null) return null;

            return new Customer
            {
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Document = origin.Document
            };
        }

        public List<Customer> Parse(List<CustomerVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public CustomerResponseVO Parse(Customer origin)
        {
            if (origin == null) return null;

            return new CustomerResponseVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Document = origin.Document,
                CreatedAt = origin.CreatedAt,
                UpdatedAt = origin.UpdatedAt
            };
        }

        public List<CustomerResponseVO> Parse(List<Customer> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public CustomerVO Parse(CustomerResponseVO origin)
        {
            if (origin == null) return null;

            return new CustomerVO
            {
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Document = origin.Document
            };
        }

        public List<CustomerVO> Parse(List<CustomerResponseVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
