namespace Lucid.Web.Models.ProductModels
{
    public class EditProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price {  get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
