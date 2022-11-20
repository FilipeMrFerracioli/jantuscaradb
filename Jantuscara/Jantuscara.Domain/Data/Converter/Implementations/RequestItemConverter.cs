namespace Jantuscara.Domain
{
    public class RequestItemConverter :
        IParser<RequestItemVO, RequestItem>,
        IParser<RequestItem, RequestItemResponseVO>
    {
        private readonly ItemConverter _itemConverter;

        public RequestItemConverter()
        {
            _itemConverter = new ItemConverter();
        }

        public RequestItem Parse(RequestItemVO origin)
        {
            if (origin == null) return null;

            return new RequestItem
            {
                Note = origin.Note,
                IdItem = origin.IdItem
            };
        }

        public List<RequestItem> Parse(List<RequestItemVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public RequestItemResponseVO Parse(RequestItem origin)
        {
            if (origin == null) return null;

            return new RequestItemResponseVO
            {
                Id = origin.Id,
                Note = origin.Note,
                IdItem = origin.IdItem,
                Item = _itemConverter.Parse(_itemConverter.Parse(origin.Item)),
                CreatedAt = origin.CreatedAt,
                UpdatedAt = origin.UpdatedAt
            };
        }

        public List<RequestItemResponseVO> Parse(List<RequestItem> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
