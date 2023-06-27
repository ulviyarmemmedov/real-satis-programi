namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.AddDTOs
{
    public class AddUpdateDto
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

        public string? DocTypeText { get; set; }
        public int? DocType { get; set; }
        public string? PlaceName { get; set; }
        public int? PlaceId { get; set; }
        public string? DocNo { get; set; }
        public DateTime? Date { get; set; }
        public int? VonderId { get; set; }
        public string? VonderName { get; set; }
    }
}
