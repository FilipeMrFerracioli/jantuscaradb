namespace Jantuscara.Domain
{
    public class RequestResponseVO
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public Customer Customer { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
