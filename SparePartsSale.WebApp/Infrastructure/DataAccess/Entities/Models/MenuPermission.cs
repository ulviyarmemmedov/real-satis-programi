using System;
using System.Collections.Generic;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models
{
    public partial class MenuPermission
    {
        public int Id { get; set; }
        public int? MenuId { get; set; }
        public int? UserType { get; set; }
        public bool? Status { get; set; }
        public int? CrUserId { get; set; }
        public DateTime? Crdate { get; set; }
    }
}
