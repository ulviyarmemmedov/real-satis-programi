using System;
using System.Collections.Generic;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models
{
    public partial class WarehouseDoc
    {
        public int Id { get; set; }
        public int? DocType { get; set; }
        public string? DocNo { get; set; }
        public DateTime? Date { get; set; }
        public int? VendorId { get; set; }
        public int? PlaceId { get; set; }
        public bool? Status { get; set; }
        public DateTime? Crdate { get; set; }
        public int? CrUserId { get; set; }
    }
}
