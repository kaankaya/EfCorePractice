﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        //navigationa lpropery
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public int StockQuantity { get; set; }
    }
}
