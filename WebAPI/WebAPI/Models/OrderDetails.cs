namespace WebAPI.Models
{
    public class OrderDetails
    {
        public int productid { get; set; }
        public decimal unitprice { get; set; }
        public int qty { get; set; }
        public decimal discount { get; set; }
    }
}
