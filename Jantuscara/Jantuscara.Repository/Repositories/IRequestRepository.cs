using Jantuscara.Domain;

namespace Jantuscara.Repository
{
    public interface IRequestRepository
    {
        public Request FindById(int id);
        public Request Create(Request request);
        public Request SetDiscount(int idRequest, int value);
        public Request PayTip(int idRequest);
        public Request CalculateAmount(int idRequest, double amount);
        public Request UpdateStatus(int idRequest, byte status);
    }
}
