namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.SaleDTOs
{
    public class SaleDetailDto
    {
        public int Id { get; set; }
        public int? SaleId { get; set; }
        public string? ProductName { get; set; }
        public double? Quantity { get; set; }
        public double? DisCount { get; set; }

        public double? Volume { get; set; }
        public double? Price { get; set; }
        public double? Total { get; set; }
        public bool? Status { get; set; }
        public DateTime? Crdate { get; set; }
    }
}
