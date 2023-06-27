using System;
using System.Collections.Generic;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        /// <summary>
        /// 0-Nagd;1-Pos
        /// </summary>
        public int? PayType { get; set; }
        public int? PlaceId { get; set; }
        public string? DocNo { get; set; }
        public DateTime? Date { get; set; }
        public int? CustomerId { get; set; }
        public bool? Status { get; set; }
        public DateTime? Crdate { get; set; }
        public int? CrUserId { get; set; }
    }
}
