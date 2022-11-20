using Jantuscara.Domain;
using Jantuscara.Repository;

namespace Jantuscara.API
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repository;
        private readonly RequestConverter _converer;
        private readonly IRequestItemService _requestItemService;
        private readonly IItemRepository _itemRepository;

        public RequestService(IRequestRepository repository, IRequestItemService requestItemService, IItemRepository itemRepository)
        {
            _repository = repository;
            _converer = new RequestConverter();
            _requestItemService = requestItemService;
            _itemRepository = itemRepository;
        }

        public RequestResponseVO Create(RequestVO request)
        {
            foreach (RequestItemVO ri in request.RequestItems)
            {
                var item = _itemRepository.FindById(ri.IdItem);
                if (item == null) return null;
            }

            var entity = _converer.Parse(request);
            entity = _repository.Create(entity);
            if (entity == null) return null;

            foreach (RequestItemVO ri in request.RequestItems)
            {
                _requestItemService.Create(entity.Id, ri);
            }

            return _converer.Parse(entity);
        }

        public RequestResponseVO FindById(int id)
        {
            var entity = _repository.FindById(id);
            return _converer.Parse(entity);
        }

        public RequestResponseVO Update(RequestVO request)
        {
            var entity = _converer.Parse(request);
            entity = _repository.Update(entity);
            return _converer.Parse(entity);
        }
    }
}
