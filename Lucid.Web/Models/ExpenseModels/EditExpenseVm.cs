using Lucid.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lucid.Web.Models.ExpenseModels
{
    public class EditExpenseVm
    {
        public int Id { get; set; }
        public int ExpenseType { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public SelectList ExpenseTypeSelectList { get; set; }
    }
}
