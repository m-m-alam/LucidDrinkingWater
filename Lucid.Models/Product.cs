﻿namespace Lucid.Models
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
