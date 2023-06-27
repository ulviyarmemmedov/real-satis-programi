namespace SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.AddDTOs
{
    public class AddReportDto
    {
        public int Id { get; set; }

        public string? ProductName { get; set; }
        public double? Quantity { get; set; }
        public double? Volume { get; set; }
        public double? Price { get; set; }

        public double? Discount { get; set; }
        public double? Total { get; set; }

        public string? DocType { get; set; }
        public string? Place { get; set; }
        public string? DocNo { get; set; }
        public DateTime? Date { get; set; }
        public string? Vendor { get; set; }
    }
}
