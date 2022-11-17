namespace Jantuscara.Domain
{
    public class RequestConverter :
        IParser<RequestVO, Request>,
        IParser<Request, RequestResponseVO>
    {
        public Request Parse(RequestVO origin)
        {
            if (origin == null) return null;

            return new Request
            {
                IdCustomer = origin.IdCustomer
            };
        }

        public List<Request> Parse(List<RequestVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public RequestResponseVO Parse(Request origin)
        {
            if (origin == null) return null;

            return new RequestResponseVO
            {
                Id = origin.Id,
                IdCustomer = origin.IdCustomer,
                Customer = origin.Customer,
                CreatedAt = origin.CreatedAt,
                UpdatedAt = origin.UpdatedAt
            };
        }

        public List<RequestResponseVO> Parse(List<Request> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
