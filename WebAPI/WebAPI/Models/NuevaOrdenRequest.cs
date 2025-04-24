namespace WebAPI.Models
{
    public class NuevaOrdenRequest
    {
        public Orders Orden { get; set; }
        public OrderDetails Detalle { get; set; }
    }

}
