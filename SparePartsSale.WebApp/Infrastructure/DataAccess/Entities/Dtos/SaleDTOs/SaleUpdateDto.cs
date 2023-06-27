namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.SaleDTOs
{
    public class SaleUpdateDto
    {
        public int Id { get; set; }

        public string? ProductName { get; set; }
        public int? ProductId { get; set; }
        public string? Barcode { get; set; }
        public double? Quantity { get; set; }
        public double? Volume { get; set; }
        public double? Price { get; set; }

        public double? Discount { get; set; }
        public double? Total { get; set; }

        public string? PayTypeText { get; set; }
        public int? PayType { get; set; }
        public string? PlaceName { get; set; }
        public int? PlaceId { get; set; }
        public string? DocNo { get; set; }
        public DateTime? Date { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
    }
}
