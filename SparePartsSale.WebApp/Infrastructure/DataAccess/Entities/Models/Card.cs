using System;
using System.Collections.Generic;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models
{
    public partial class Card
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public int? Value { get; set; }
        public string Text { get; set; } = null!;
        public bool? Status { get; set; }
        public DateTime? Crdate { get; set; }
        public int? CrUserId { get; set; }
    }
}
