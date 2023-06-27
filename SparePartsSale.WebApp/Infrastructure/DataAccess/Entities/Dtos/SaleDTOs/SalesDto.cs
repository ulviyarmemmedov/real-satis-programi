using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models;

namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.SaleDTOs
{
    public class SalesDto
    {
        public List<SaleDetailDto> SaleDetails { get; set; }
        public Sale SaleInfo { get; set; }
    }
}
