using Microsoft.AspNetCore.Mvc.Rendering;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models;

namespace SparePartsSale.WebApp.Models.SaleVMs
{
    public class SaleAddViewModel
    {
        public Sale? Sale { get; set; }
        public List<SaleDetail>? SaleDetail { get; set; }
        public List<SelectListItem>? CompanyList { get; set; }
        public List<SelectListItem>? PlaceList { get; set; }
        public List<SelectListItem>? PayTypeList { get; set; }
    }

}
