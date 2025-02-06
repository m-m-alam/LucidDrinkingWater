namespace Lucid.Models
{
    public class CustomerType : AuditableEntity
    {
        public CustomerType()
        {
            Customers = new List<Customer>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        List<Customer> Customers { get; set; }
    }
}
