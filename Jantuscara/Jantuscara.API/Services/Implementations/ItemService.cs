using Jantuscara.Domain;
using Jantuscara.Repository;

namespace Jantuscara.API
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;
        private readonly ItemConverter _converter;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
            _converter = new ItemConverter();
        }

        public ItemResponseVO Create(ItemVO item)
        {
            var entity = _converter.Parse(item);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }

        public List<ItemResponseVO> FindAll()
        {
            var entity = _repository.FindAll();
            return _converter.Parse(entity);
        }

        public ItemResponseVO FindById(int id)
        {
            var entity = _repository.FindById(id);
            return _converter.Parse(entity);
        }

        public ItemResponseVO Update(ItemVO item)
        {
            var entity = _converter.Parse(item);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }
    }
}
