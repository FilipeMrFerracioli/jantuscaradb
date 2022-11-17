namespace Jantuscara.Domain
{
    public class Request : BaseDomain
    {
        public bool Tip { get; set; }
        public double Discount { set; get; }
        public double Amount { get; set; }
        public OrderStatus Status { get; set; }
        public int IdCustomer { get; set; }
        public virtual Customer Customer { get; set; }
        //public virtual List<Item> Items { get; set; }
        public virtual List<RequestItem> RequestItems { get; set; }
    }
}