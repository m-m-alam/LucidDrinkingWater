﻿namespace Lucid.Models
{
    public class ExpenseType : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description {  get; set; }
    }
}
