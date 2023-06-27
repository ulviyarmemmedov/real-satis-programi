using Microsoft.AspNetCore.Mvc.Rendering;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.AddDTOs;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.SaleDTOs;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models;

namespace SparePartsSale.WebApp.Models.AddVMs
{
    public class AddUpdateVm
    {
        public WarehouseDoc? WarehouseDocs { get; set; }
        public List<WarehouseDocDetail>? WarehouseDocDetails { get; set; }
        public List<SelectListItem>? CompanyList { get; set; }
        public List<SelectListItem>? PlaceList { get; set; }
        public List<SelectListItem>? PayTypeList { get; set; }

        public List<AddUpdateDto> Product { get; set; }
    }
}
