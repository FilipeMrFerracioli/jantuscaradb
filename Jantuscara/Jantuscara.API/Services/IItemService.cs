using Jantuscara.Domain;

namespace Jantuscara.API
{
    public interface IItemService
    {
        public List<ItemResponseVO> FindAll();
        public ItemResponseVO FindById(int id);
        public ItemResponseVO Create(ItemVO item);
        public ItemResponseVO Update(ItemVO item);
    }
}
