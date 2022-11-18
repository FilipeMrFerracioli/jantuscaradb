using Jantuscara.Domain;

namespace Jantuscara.API
{
    public interface IRequestService
    {
        public RequestResponseVO FindById(int id);
        public RequestResponseVO Create(RequestVO request);
        public RequestResponseVO Update(RequestVO request);
    }
}
