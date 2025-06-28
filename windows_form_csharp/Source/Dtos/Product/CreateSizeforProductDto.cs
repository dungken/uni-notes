namespace api.Dtos.Product
{
    public class CreateSizeforProductDto
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }

        public Guid ProductId { get; set; }
    }
}
