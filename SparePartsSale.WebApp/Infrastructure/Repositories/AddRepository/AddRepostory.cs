using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.AddDTOs;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.SaleDTOs;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models;
using SparePartsSale.WebApp.Infrastructure.DataAccess.EntityFramework.Contexts;

namespace SparePartsSale.WebApp.Infrastructure.Repositories.AddRepository
{
    public class AddRepostory
    {
        SaleAppDbContext db;
        public AddRepostory()
        {
            db = new SaleAppDbContext();
        }

        public void AddWarehouseDoc(WarehouseDoc data)
        {
            db.WarehouseDocs.Add(data);
            db.SaveChanges();
        }

        public void AddWarehouseDocDetail(List<AddProductDetailDto> data)
        {
            foreach (var item in data)
            {
                var latestSale = db.WarehouseDocs.OrderByDescending(s => s.Id).FirstOrDefault();

                var SerachData = db.Products.FirstOrDefault(x => x.Name == item.ProductName);
                WarehouseDocDetail ob = new WarehouseDocDetail()
                {
                    WarehouseDocId = latestSale.Id,
                    ProductId = SerachData.Id,
                    Quantity = item.Quantity,
                    Volume = item.Volume,
                    Price = item.Price,
                    Total = item.Total,
                   Discount=item.Discount



                };

                db.WarehouseDocDetails.Add(ob);
            }
            db.SaveChanges();
        }
        public List<AddReportDto> AddReport()
        {

            var query = from sd in db.WarehouseDocDetails
                        join pr in db.Products on sd.ProductId equals pr.Id
                        join s in db.WarehouseDocs on sd.WarehouseDocId equals s.Id into saleGroup
                        from sale in saleGroup.DefaultIfEmpty()
                        join p in db.Places on sale != null ? sale.PlaceId : (int?)null equals p.Id into placeGroup
                        from place in placeGroup.DefaultIfEmpty()
                        join pay in db.Cards on sale != null ? sale.DocType : (int?)null equals pay.Id into cardGroup
                        from card in cardGroup.DefaultIfEmpty()
                        join c in db.Companies on sale != null ? sale.VendorId : (int?)null equals c.Id into companyGroup
                        from company in companyGroup.DefaultIfEmpty()
                        select new AddReportDto
                        {
                            Id = sd.Id,
                            Total = sd.Total,
                            DocType = card != null ? card.Text : null,
                            Discount = sd.Discount,
                            Place = place != null ? place.Name : null,
                            DocNo = sale != null ? sale.DocNo : null,
                            Date = sale != null ? sale.Date : (DateTime?)null,
                            Vendor = company != null ? company.Name : null
                        };

            var list = query.OrderByDescending(x => x.Id).ToList();
            return list;
        }
        public void Delete(int id)
        {
            var WarehouseDocDetailItem = db.WarehouseDocDetails.FirstOrDefault(s => s.Id == id);
            var WarehouseDocsItem = db.WarehouseDocs.FirstOrDefault(x => x.Id == WarehouseDocDetailItem.WarehouseDocId);
            var data = db.WarehouseDocDetails.Where(x => x.WarehouseDocId == WarehouseDocsItem.Id).ToList();

            db.WarehouseDocDetails.Remove(WarehouseDocDetailItem);
            if (data.Count() == 1)
            {
                db.WarehouseDocs.Remove(WarehouseDocsItem);
            }
            db.SaveChanges();
        }

    }
}
