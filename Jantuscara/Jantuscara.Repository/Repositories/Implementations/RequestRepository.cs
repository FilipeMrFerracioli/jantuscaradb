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
                    .FirstOrDefault(x => x.Id.Equals(id));
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

        public Request SetDiscount(int idRequest, int value)
        {
            if (idRequest <= 0 || value < 0 || value > 100) return null;
            try
            {
                var request = _context.Requests.FirstOrDefault(x => x.Id.Equals(idRequest));
                if (request == null) return null;

                //request.Discount = value;
                //_context.Entry(request).CurrentValues.SetValues(request); com LINQ
                _context.Database.ExecuteSqlRaw(@"UPDATE requests"
                                             + " SET discount = {0},"
                                             + " updated_at = {2}"
                                             + " WHERE id = {1}", value, idRequest, DateTime.UtcNow);
                _context.SaveChanges();

                request = _context.Requests
                    .Include(x => x.Customer)
                    .Include(x => x.RequestItems)
                    .FirstOrDefault(x => x.Id.Equals(idRequest));

                return request;
            }
            catch (Exception) { throw; }
        }

        public Request PayTip(int idRequest)
        {
            if (idRequest <= 0) return null;
            try
            {
                var request = _context.Requests.FirstOrDefault(x => x.Id.Equals(idRequest));
                if (request == null) return null;

                //request.Discount = value;
                //_context.Entry(request).CurrentValues.SetValues(request); com LINQ
                _context.Database.ExecuteSqlRaw(@"UPDATE requests"
                                             + " SET tip = 1,"
                                             + " updated_at = {1}"
                                             + " WHERE id = {0}", idRequest, DateTime.UtcNow);
                _context.SaveChanges();

                request = _context.Requests
                    .Include(x => x.Customer)
                    .Include(x => x.RequestItems)
                    .FirstOrDefault(x => x.Id.Equals(idRequest));

                return request;
            }
            catch (Exception) { throw; }
        }

        public Request CalculateAmount(int idRequest, double amount)
        {
            if (idRequest <= 0 || amount < 0) return null;
            try
            {
                var request = _context.Requests.FirstOrDefault(x => x.Id.Equals(idRequest));
                if (request == null) return null;

                //request.Discount = value;
                //_context.Entry(request).CurrentValues.SetValues(request); com LINQ
                _context.Database.ExecuteSqlRaw(@"UPDATE requests"
                                             + " SET amount = {0},"
                                             + " updated_at = {2}"
                                             + " WHERE id = {1}", amount, idRequest, DateTime.UtcNow);
                _context.SaveChanges();

                request = _context.Requests
                    .Include(x => x.Customer)
                    .Include(x => x.RequestItems)
                    .FirstOrDefault(x => x.Id.Equals(idRequest));

                return request;
            }
            catch (Exception) { throw; }
        }

        public Request UpdateStatus(int idRequest, byte status)
        {
            if (idRequest <= 0 || status < 0) return null;
            try
            {
                var request = _context.Requests.FirstOrDefault(x => x.Id.Equals(idRequest));
                if (request == null) return null;

                //request.Discount = value;
                //_context.Entry(request).CurrentValues.SetValues(request); com LINQ
                _context.Database.ExecuteSqlRaw(@"UPDATE requests"
                                             + " SET status = {0},"
                                             + " updated_at = {2}"
                                             + " WHERE id = {1}", status, idRequest, DateTime.UtcNow);
                _context.SaveChanges();

                request = _context.Requests
                    .Include(x => x.Customer)
                    .Include(x => x.RequestItems)
                    .FirstOrDefault(x => x.Id.Equals(idRequest));

                return request;
            }
            catch (Exception) { throw; }
        }
    }
}
