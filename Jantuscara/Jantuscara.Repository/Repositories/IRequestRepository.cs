using Jantuscara.Domain;

namespace Jantuscara.Repository
{
    public interface IRequestRepository
    {
        public Request FindById(int id);
        public Request Create(Request request);
        public Request Update(Request request);
    }
}
