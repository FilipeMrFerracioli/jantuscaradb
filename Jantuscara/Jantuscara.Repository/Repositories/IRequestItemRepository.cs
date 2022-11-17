using Jantuscara.Domain;

namespace Jantuscara.Repository
{
    public interface IRequestItemRepository
    {
        public RequestItem FindById(int id);
        public RequestItem Create(RequestItem requestItem);
        //public Request Update(Request request);
    }
}
