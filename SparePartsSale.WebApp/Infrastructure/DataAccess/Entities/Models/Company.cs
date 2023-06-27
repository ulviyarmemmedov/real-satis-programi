using System;
using System.Collections.Generic;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models
{
    public partial class Company
    {
        public int Id { get; set; }
        /// <summary>
        /// 0 Musteri;1 Vendor
        /// </summary>
        public byte? Type { get; set; }
        public string? Name { get; set; }
        public string? PlateNumber { get; set; }
        public string? Phone { get; set; }
        public bool? Status { get; set; }
        public DateTime? Crdate { get; set; }
        public int? CrUserId { get; set; }
    }
}
