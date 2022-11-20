namespace Jantuscara.Domain
{
    public class RequestItemResponseVO
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public int IdItem { get; set; }
        public ItemVO Item { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
