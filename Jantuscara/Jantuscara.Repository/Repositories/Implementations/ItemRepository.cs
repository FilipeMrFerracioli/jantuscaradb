using Jantuscara.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jantuscara.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly MySqlDbContext _context;

        public ItemRepository(MySqlDbContext context)
        {
            _context = context;
        }

        public List<Item> FindAll()
        {
            try
            {
                //var result = _context.Items.ToList(); com LINQ
                var result = _context.Items.FromSqlRaw("SELECT * FROM items").ToList();

                if (result == null) return null;

                return result;
            }
            catch (Exception) { throw; }
        }

        public Item FindById(int id)
        {
            if (id <= 0) return null;
            try
            {
                //var result = _context.Items.SingleOrDefault(x => x.Id.Equals(id)); com LINQ
                var result = _context.Items.FromSqlRaw($"SELECT * FROM items WHERE id = {id}").FirstOrDefault();

                if (result == null) return null;

                return result;
            }
            catch (Exception) { throw; }
        }

        public Item Create(Item item)
        {
            if (item == null) return null;
            try
            {
                //_context.Items.Add(item); com LINQ
                _context.Database.ExecuteSqlRaw(@"INSERT INTO items (name, price, description, img_url)"
                                                + " VALUES ({0}, {1}, {2}, {3})",
                                                item.Name, item.Price, item.Description, item.ImgURL);
                _context.SaveChanges();

                return item;
            }
            catch (Exception) { throw; }
        }

        public Item Update(Item item)
        {
            if (item == null) return null;
            try
            {
                var result = _context.Items.SingleOrDefault(x => x.Id.Equals(item.Id));

                if (result == null) return null;

                item.Id = result.Id;
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();

                return item;
            }
            catch (Exception) { throw; }
        }
    }
}
