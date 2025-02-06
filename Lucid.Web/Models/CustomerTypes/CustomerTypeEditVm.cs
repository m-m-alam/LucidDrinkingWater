namespace Lucid.Web.Models.CustomerTypes
{
    public class CustomerTypeEditVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
