using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.SaleDTOs;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.AddDTOs
{
    public class AddDto
    {
        public List<AddProductDetailDto> addDetails { get; set; }
        public WarehouseDoc addInfo { get; set; }
    }
}
