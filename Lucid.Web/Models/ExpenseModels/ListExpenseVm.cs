using Lucid.Models;

namespace Lucid.Web.Models.ExpenseModels
{
    public class ListExpenseVm
    {
        public int Id { get; set; }
        public string ExpenseTypeName { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
