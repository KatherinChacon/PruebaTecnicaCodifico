namespace WebAPI.Models
{
    public class Orders
    {
        public int empid { get; set; }
        public int shipperid { get; set; }
        public string? shipname { get; set; }
        public string? shipaddress { get; set; }
        public string? shipcity { get; set; }
        public DateTime orderdate { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime shippeddate { get; set; }
        public Decimal freight { get; set; }
        public string? Shipcountry { get; set; }
    }
}
