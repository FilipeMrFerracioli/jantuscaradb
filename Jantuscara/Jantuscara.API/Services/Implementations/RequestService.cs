using Jantuscara.Domain;
using Jantuscara.Repository;

namespace Jantuscara.API
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repository;
        private readonly RequestConverter _converter;
        private readonly IRequestItemService _requestItemService;
        private readonly IItemRepository _itemRepository;

        public RequestService(IRequestRepository repository, IRequestItemService requestItemService, IItemRepository itemRepository)
        {
            _repository = repository;
            _converter = new RequestConverter();
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

            var entity = _converter.Parse(request);
            entity = _repository.Create(entity);
            if (entity == null) return null;

            foreach (RequestItemVO ri in request.RequestItems)
            {
                _requestItemService.Create(entity.Id, ri);
            }

            return _converter.Parse(entity);
        }

        public RequestResponseVO FindById(int id)
        {
            var entity = _repository.FindById(id);
            return _converter.Parse(entity);
        }

        public RequestResponseVO SetDiscount(int idRequest, int value)
        {
            var entity = _repository.SetDiscount(idRequest, value);

            return _converter.Parse(entity);
        }

        public RequestResponseVO PayTip(int idRequest)
        {
            var entity = _repository.PayTip(idRequest);

            return _converter.Parse(entity);
        }

        public RequestResponseVO CalculateAmount(int idRequest)
        {
            var entity = _repository.FindById(idRequest);

             double amount = 0;

            foreach(RequestItem ri in entity.RequestItems)
            {
                Item item = _itemRepository.FindById(ri.IdItem);

                amount += item.Price;
            }

            entity = _repository.CalculateAmount(idRequest, entity.CalculateAmount(amount));

            return _converter.Parse(entity);
        }

        public RequestResponseVO UpdateStatus(int idRequest, OrderStatus status)
        {
            var entity = _repository.UpdateStatus(idRequest, (byte)status);

            return _converter.Parse(entity);
        }
    }
}
