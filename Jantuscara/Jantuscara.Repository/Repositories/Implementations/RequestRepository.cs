using Jantuscara.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jantuscara.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly MySqlDbContext _context;

        public RequestRepository(MySqlDbContext context)
        {
            _context = context;
        }

        public Request FindById(int id)
        {
            if (id <= 0) return null;
            try
            {
                var result = _context.Requests
                    .Include(x => x.Customer)
                    .Include(x => x.RequestItems)
                    .SingleOrDefault(x => x.Id.Equals(id));
                /*
                 SELECT * FROM requests
                    INNER JOIN customers
                    ON id_customer = customers.id
                    INNER JOIN requestitems
                    ON id_request = requestitems.id
                 WHERE requests.id = <id>;
                 ----------------------------------
                 O EF não aceita query bruta com relações (junções).
                 Exemplo acima de como seria uma query SQL!
                 */

                if (result == null) return null;

                return result;
            }
            catch (Exception) { throw; }
        }

        public Request Create(Request request)
        {
            if (request == null) return null;
            try
            {
                //var customer = _context.Customers.FirstOrDefault(x => x.Id.Equals(request.IdCustomer)); com LINQ
                var customer = _context.Customers.FromSqlRaw($"SELECT * FROM customers WHERE id = {request.IdCustomer}").SingleOrDefault();
                if (customer == null) return null;

                _context.Requests.Add(request);
                _context.SaveChanges();

                return request;
            }
            catch (Exception) { throw; }
        }

        public Request Update(Request request)
        {
            if (request == null) return null;
            try
            {
                var result = _context.Requests.SingleOrDefault(x => x.Id.Equals(request.Id));
                if (result == null) return null;

                var customer = _context.Customers.FirstOrDefault(x => x.Id.Equals(request.IdCustomer));
                if (customer == null) return null;

                request.Id = result.Id;
                request.IdCustomer = customer.Id;
                _context.Entry(result).CurrentValues.SetValues(request);
                _context.SaveChanges();

                return request;
            }
            catch (Exception) { throw; }
        }
    }
}
