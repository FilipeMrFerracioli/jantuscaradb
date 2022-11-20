using Jantuscara.Domain;

namespace Jantuscara.API
{
    public interface IRequestService
    {
        public RequestResponseVO FindById(int id);
        public RequestResponseVO Create(RequestVO request);
        public RequestResponseVO SetDiscount(int idRequest, int value);
        public RequestResponseVO PayTip(int idRequest);
        public RequestResponseVO CalculateAmount(int idRequest);
        public RequestResponseVO UpdateStatus(int idRequest, OrderStatus status);
    }
}
