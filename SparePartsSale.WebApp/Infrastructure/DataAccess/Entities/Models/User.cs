using System;
using System.Collections.Generic;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public int? PlaceId { get; set; }
        /// <summary>
        /// 0-Site;1-Admin
        /// </summary>
        public int? UserType { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
