namespace Jantuscara.Domain
{
    public class ItemConverter :
        IParser<ItemVO, Item>,
        IParser<Item, ItemResponseVO>
    {
        public Item Parse(ItemVO origin)
        {
            if (origin == null) return null;

            return new Item
            {
                Name = origin.Name,
                Price = origin.Price,
                Description = origin.Description,
                ImgURL = origin.Description
            };
        }

        public List<Item> Parse(List<ItemVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public ItemResponseVO Parse(Item origin)
        {
            if (origin == null) return null;

            return new ItemResponseVO
            {
                Id = origin.Id,
                Name = origin.Name,
                Price = origin.Price,
                Description = origin.Description,
                ImgURL = origin.Description,
                CreatedAt = origin.CreatedAt,
                UpdatedAt = origin.UpdatedAt
            };
        }

        public List<ItemResponseVO> Parse(List<Item> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
