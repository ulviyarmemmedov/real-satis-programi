using System;
using System.Collections.Generic;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models
{
    public partial class WarehouseDocDetail
    {
        public int Id { get; set; }
        public int? WarehouseDocId { get; set; }
        public int? ProductId { get; set; }
        public double? Quantity { get; set; }
        public double? Volume { get; set; }
        public double? Price { get; set; }
        public double? Total { get; set; }
        public double? Discount { get; set; }
        public bool? Status { get; set; }
    }
}
