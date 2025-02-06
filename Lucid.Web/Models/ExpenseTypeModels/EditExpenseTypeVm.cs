namespace Lucid.Web.Models.ExpenseTypeModels
{
    public class EditExpenseTypeVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
