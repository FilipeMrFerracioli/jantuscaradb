using Jantuscara.Domain;
using Microsoft.EntityFrameworkCore;

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
                //var result = _context.RequestItems.FirstOrDefault(x => x.Id.Equals(id)); com LINQ
                var result = _context.RequestItems.FromSqlRaw(@"SELECT * FROM requestitems WHERE = {0}", id).FirstOrDefault();

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
                //var item = _context.Items.SingleOrDefault(x => x.Id.Equals(requestItem.IdItem)); com LINQ
                var item = _context.Items.FromSqlRaw($"SELECT * FROM items WHERE id = {requestItem.IdItem}").FirstOrDefault();
                if (item == null) return null;

                _context.RequestItems.Add(requestItem);
                _context.SaveChanges();

                return requestItem;
            }
            catch (Exception) { throw; }
        }
    }
}
