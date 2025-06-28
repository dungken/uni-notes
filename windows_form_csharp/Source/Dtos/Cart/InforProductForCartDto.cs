namespace api.Dtos.Cart
{
    public class InforProductForCartDto
    {
        public Guid ProductId { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; } = 1;
        
    }
}
