using Jantuscara.Domain;

namespace Jantuscara.Repository
{
    public class RequestItemRepository : IRequestItemRepository
    {
        private readonly MySqlDbContext _context;

        public RequestItemRepository(MySqlDbContext context)
        {
            _context = context;
        }

        public RequestItem FindById(int id)
        {
            if (id <= 0) return null;
            try
            {
                var result = _context.RequestItems.SingleOrDefault(x => x.Id.Equals(id));

                if (result == null) return null;

                return result;
            }
            catch (Exception) { throw; }
        }

        public RequestItem Create(RequestItem requestItem)
        {
            if (requestItem == null) return null;
            try
            {
                _context.RequestItems.Add(requestItem);
                _context.SaveChanges();

                return requestItem;
            }
            catch (Exception) { throw; }
        }

        //public Request Update(Request request)
        //{
        //    if (request == null) return null;
        //    try
        //    {
        //        var result = _context.Requests.SingleOrDefault(x => x.Id.Equals(request.Id));

        //        if (result == null) return null;

        //        request.Id = result.Id;
        //        _context.Entry(result).CurrentValues.SetValues(request);
        //        _context.SaveChanges();

        //        return request;
        //    }
        //    catch (Exception) { throw; }
        //}
    }
}
