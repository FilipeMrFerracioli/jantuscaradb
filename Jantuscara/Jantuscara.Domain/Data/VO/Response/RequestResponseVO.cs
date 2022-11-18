namespace Jantuscara.Domain
{
    public class RequestResponseVO
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public CustomerVO Customer { get; set; }
        public List<RequestItemResponseVO> RequestItems { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
