namespace WebAPI.Models
{
    public class ClientPrediction
    {
        public int IdCliente { get; set; }
        public string? CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
