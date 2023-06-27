using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.SaleDTOs;

namespace SparePartsSale.WebApp.Models.SaleVMs
{
    public class ReportVM
    {
        public List<ReportDto> Report { get; set; }
    }
}
