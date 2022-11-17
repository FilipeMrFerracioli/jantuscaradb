using Jantuscara.Domain;

namespace Jantuscara.Repository
{
    public interface IItemRepository
    {
        public List<Item> FindAll();
        public Item FindById(int id);
        public Item Create(Item item);
        public Item Update(Item item);
    }
}
