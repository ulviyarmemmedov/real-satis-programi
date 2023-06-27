using System;
using System.Collections.Generic;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models
{
    public partial class PlaceShelf
    {
        public int Id { get; set; }
        public int? PlaceId { get; set; }
        public string? ShelfBarcode { get; set; }
        public string? ShelfName { get; set; }
        public int? ShelfRow { get; set; }
        public int? ShelfColumn { get; set; }
        public bool? Status { get; set; }
        public DateTime? Crdate { get; set; }
        public int? CrUserId { get; set; }
    }
}
