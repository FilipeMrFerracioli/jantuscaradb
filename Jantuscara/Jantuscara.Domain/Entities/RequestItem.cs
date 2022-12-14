namespace Jantuscara.Domain
{
    public class RequestItem : BaseDomain
    {
        public string Note { get; set; }
        public int IdRequest { get; set; }
        public virtual Request Request { get; set; }
        public int IdItem { get; set; }
        public virtual Item Item { get; set; }
    }
}