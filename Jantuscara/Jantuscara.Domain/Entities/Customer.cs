namespace Jantuscara.Domain
{
    public class Customer : BaseDomain
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public virtual List<Request> Requests { get; set; }
    }
}