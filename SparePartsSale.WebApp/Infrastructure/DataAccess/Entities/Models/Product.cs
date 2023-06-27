using System;
using System.Collections.Generic;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Barcode { get; set; }
        public double? Volume { get; set; }
        public bool? StockCalculation { get; set; }
        public double? Price { get; set; }
        public bool? Status { get; set; }
        public DateTime? Crdate { get; set; }
        public int? CrUserId { get; set; }
    }
}
