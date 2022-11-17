namespace Jantuscara.Domain
{
    public class Item : BaseDomain
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImgURL { get; set; }
        //public virtual List<Request> Requests { get; set; }
        public virtual List<RequestItem> RequestItems { get; set; }
    }
}