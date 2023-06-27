using System;
using System.Collections.Generic;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models
{
    public partial class SaleDetail
    {
        public int Id { get; set; }
        public int? SaleId { get; set; }
        public int? ProductId { get; set; }
        public double? Quantity { get; set; }
        public double? DisCount { get; set; }
        public double? Volume { get; set; }
        public double? Price { get; set; }
        public double? Total { get; set; }
        public bool? Status { get; set; }
        public DateTime? Crdate { get; set; }
    }
}
