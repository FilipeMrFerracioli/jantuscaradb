using Jantuscara.Domain;

namespace Jantuscara.API
{
    public interface IRequestItemService
    {
        public RequestItemResponseVO FindById(int id);
        public RequestItemResponseVO Create(int idRequest, RequestItemVO requestItem);
        //public Request Update(Request request);
    }
}
