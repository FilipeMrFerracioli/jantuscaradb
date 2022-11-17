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
        public virtual List<RequestItem> RequestItems { get; set; }

        public void CalculateAmount(double valueItems)
        {
            valueItems += valueItems * (Discount / 100);

            if (Tip)
            {
                valueItems += valueItems * (10 / 100);
            }

            Amount = valueItems;
            //return valueItems;
        }
    }
}