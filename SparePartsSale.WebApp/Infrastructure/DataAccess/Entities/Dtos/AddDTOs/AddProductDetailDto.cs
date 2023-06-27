namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.AddDTOs
{
    public class AddProductDetailDto
    {
        public int Id { get; set; }
        public int? WarehouseDocId { get; set; }
        public string? ProductName { get; set; }
        public double? Quantity { get; set; }
        public double? Volume { get; set; }
        public double? Price { get; set; }
        public double? Total { get; set; }
        public double? Discount { get; set; }
        public bool? Status { get; set; }
    }
}
