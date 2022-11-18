using Jantuscara.Domain;
using Jantuscara.Repository;

namespace Jantuscara.API
{
    public class RequestItemService : IRequestItemService
    {
        private readonly IRequestItemRepository _repository;
        private readonly RequestItemConverter _converter;

        public RequestItemService(IRequestItemRepository repository)
        {
            _repository = repository;
            _converter = new RequestItemConverter();
        }

        public RequestItemResponseVO FindById(int id)
        {
            var entity = _repository.FindById(id);

            return _converter.Parse(entity);
        }

        public RequestItemResponseVO Create(int idRequest, RequestItemVO requestItem)
        {
            var entity = new RequestItem
            {
                Note = requestItem.Note,
                IdRequest = idRequest,
                IdItem = requestItem.IdItem
            };

            entity = _repository.Create(entity);

            return _converter.Parse(entity);
        }
    }
}
