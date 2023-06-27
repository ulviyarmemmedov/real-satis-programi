using System;
using System.Collections.Generic;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models
{
    public partial class Menu
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public byte? Type { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }
        public bool? Status { get; set; }
        public byte? Orderby { get; set; }
    }
}
