﻿namespace Lucid.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int ExpenseTypeId { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public double Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public ExpenseType ExpenseType { get; set; }
    }
}
