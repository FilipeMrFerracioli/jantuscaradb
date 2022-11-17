using Jantuscara.Domain;

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
                var result = _context.Items.ToList();

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
                var result = _context.Items.SingleOrDefault(x => x.Id.Equals(id));

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
                _context.Items.Add(item);
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
