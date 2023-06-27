using System;
using System.Collections.Generic;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models
{
    public partial class Warehouse
    {
        public int Id { get; set; }
        public int? PlaceId { get; set; }
        public string? Name { get; set; }
        public bool? Status { get; set; }
        public DateTime? Crdate { get; set; }
        public int? CrUserId { get; set; }
    }
}
