namespace Lucid.Models
{
    public class SaleDetails : IEntity
    {
        public int ProductId { get; set; }
        public double? Price { get; set; }
        public int? Delivery { get; set; }
        public int? Return { get; set; }
        public int? Stock { get; set; }

        public Product Product { get; set; }
    }
}
