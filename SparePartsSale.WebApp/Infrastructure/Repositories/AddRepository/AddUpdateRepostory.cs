using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.AddDTOs;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.SaleDTOs;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models;
using SparePartsSale.WebApp.Infrastructure.DataAccess.EntityFramework.Contexts;

namespace SparePartsSale.WebApp.Infrastructure.Repositories.AddRepository
{
    public class AddUpdateRepostory
    {
        SaleAppDbContext db;
        public AddUpdateRepostory()
        {
            db = new SaleAppDbContext();
        }
        public string GetDocNo(int UserId)
        {
            var data = db.WarehouseDocs.OrderByDescending(x => x.Id).FirstOrDefault();
            string DocNo = data == null ? "" : data.DocNo;
            // DocNo = "012312000001";
            string PlaceId = db.Users.Where(x => x.Id == UserId && x.Status == true).FirstOrDefault().PlaceId.ToString().PadLeft(2, '0');
            string Year = DateTime.Now.ToString("yy");
            string Month = DateTime.Now.ToString("MM").PadLeft(2, '0');
            if (DocNo != "")
            {
                DocNo = (int.Parse(DocNo.Substring(6, DocNo.Length - 6)) + 1).ToString();
            }
            else
            {
                DocNo = "000001";
            }

            DocNo = PlaceId + Year + Month + DocNo.PadLeft(6, '0');
            return DocNo;
        }
        public IQueryable<Company> GetCompany(byte type, int id)
        {
            var WarehouseDocDetailItem = db.WarehouseDocDetails.FirstOrDefault(x => x.Id == id);
            var WarehouseDocitem = db.WarehouseDocs.FirstOrDefault(x => x.Id == WarehouseDocDetailItem.WarehouseDocId);
            var data = db.Companies.Where(x => x.Type == type && x.Status == true && x.Id != WarehouseDocitem.VendorId).OrderBy(x => x.Name);
            return data;
        }

        public IQueryable<Place> GetPlace(int userId, int id)
        {
            var WarehouseDocDetailItem = db.WarehouseDocDetails.FirstOrDefault(x => x.Id == id);
            var WarehouseDocitem = db.WarehouseDocs.FirstOrDefault(x => x.Id == WarehouseDocDetailItem.WarehouseDocId);
            var PlaceId = db.Users.Where(x => x.Id == userId && x.Status == true).FirstOrDefault().PlaceId;

            var data = db.Places.Where(x => x.Id == PlaceId && x.Id != WarehouseDocitem.PlaceId);

            return data;
        }

        public IQueryable<Card> GetCard(string type, int id)
        {
            var WarehouseDocDetailItem = db.WarehouseDocDetails.FirstOrDefault(x => x.Id == id);
            var WarehouseDocitem = db.WarehouseDocs.FirstOrDefault(x => x.Id == WarehouseDocDetailItem.WarehouseDocId);
            var data = db.Cards.Where(x => x.Type == type && x.Status == true && x.Id != WarehouseDocitem.DocType).OrderBy(x => x.Text);
            return data;
        }

        public Product GetProduct(string Barcode)
        {
            var data = db.Products.Where(x => x.Status == true && x.Barcode == Barcode).FirstOrDefault();
            return data;
        }

        public List<AddUpdateDto> GetRepostory(int id)
        {
            var query = from sl in db.WarehouseDocDetails
                        join s in db.WarehouseDocs on sl.WarehouseDocId equals s.Id
                        join p in db.Products on sl.ProductId equals p.Id
                        join c in db.Cards on s.DocType equals c.Id
                        join pl in db.Places on s.PlaceId equals pl.Id
                        join com in db.Companies on s.VendorId equals com.Id
                        where sl.Id == id
                        select new AddUpdateDto
                        {
                            Id = sl.Id,
                            ProductName = p.Name,
                            ProductId = p.Id,
                            Barcode = p.Barcode,
                            DocTypeText = c.Text,
                            Discount = sl.Discount,
                            PlaceName = pl.Name,
                            Quantity = sl.Quantity,
                            Volume = sl.Volume,
                            Price = sl.Price,
                            Total = sl.Total,
                            DocType = s.DocType,
                            PlaceId = s.PlaceId,
                            DocNo = s.DocNo,
                            Date = s.Date,
                            VonderId = s.VendorId,
                            VonderName = com.Name
                        };
            var data = query.ToList();
            return data;
        }


        public void AddDetailUpdate(AddDto data)
        {

            var d = data.addDetails[0];
            var ds = data.addInfo;

            var sd = db.WarehouseDocDetails.FirstOrDefault(x => x.Id == d.Id);
            var s = db.WarehouseDocs.FirstOrDefault(x => x.Id == sd.WarehouseDocId);
            var product = db.Products.FirstOrDefault(x => x.Name == d.ProductName);
            sd.WarehouseDocId = s.Id;
            sd.ProductId = product.Id;
            sd.Quantity = d.Quantity;
            sd.Discount = d.Discount;
            sd.Volume = d.Volume;
            sd.Price = d.Price;
            sd.Total = d.Total;
            s.DocType = ds.DocType;
            s.PlaceId = ds.PlaceId;
            s.DocNo = ds.DocNo;
            s.Date = ds.Date;
            s.VendorId = ds.VendorId;


            db.WarehouseDocDetails.Update(sd);
            db.WarehouseDocs.Update(s);


            db.SaveChanges();
        }
    }
}
