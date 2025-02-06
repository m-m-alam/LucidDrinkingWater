namespace Lucid.Web.Models.VanModels
{
    public class VanEditVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Driver { get; set; }
        public string Mobile { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
