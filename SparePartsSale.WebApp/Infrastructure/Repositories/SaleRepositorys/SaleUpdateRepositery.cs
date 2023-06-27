using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.SaleDTOs;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models;
using SparePartsSale.WebApp.Infrastructure.DataAccess.EntityFramework.Contexts;

namespace SparePartsSale.WebApp.Infrastructure.Repositories.SaleRepositorys
{
    public class SaleUpdateRepositery
    {
        SaleAppDbContext db;
        public SaleUpdateRepositery()
        {
            db = new SaleAppDbContext();
        }
        public string GetDocNo(int UserId)
        {
            var data = db.Sales.OrderByDescending(x => x.Id).FirstOrDefault();
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
            var SaleDatilItem = db.SaleDetails.FirstOrDefault(x => x.Id == id);
            var saleitem = db.Sales.FirstOrDefault(x => x.Id == SaleDatilItem.SaleId);
            var data = db.Companies.Where(x => x.Type == type && x.Status == true && x.Id != saleitem.CustomerId).OrderBy(x => x.Name);
            return data;
        }

        public IQueryable<Place> GetPlace(int userId, int id)
        {
            var SaleDatilItem = db.SaleDetails.FirstOrDefault(x => x.Id == id);
            var saleitem = db.Sales.FirstOrDefault(x => x.Id == SaleDatilItem.SaleId);
            var PlaceId = db.Users.Where(x => x.Id == userId && x.Status == true).FirstOrDefault().PlaceId;

            var data = db.Places.Where(x => x.Id == PlaceId && x.Id != saleitem.PlaceId);

            return data;
        }

        public IQueryable<Card> GetCard(string type, int id)
        {
            var SaleDatilItem = db.SaleDetails.FirstOrDefault(x => x.Id == id);
            var saleitem = db.Sales.FirstOrDefault(x => x.Id == SaleDatilItem.SaleId);
            var data = db.Cards.Where(x => x.Type == type && x.Status == true && x.Id != saleitem.PayType).OrderBy(x => x.Text);
            return data;
        }

        public Product GetProduct(string Barcode)
        {
            var data = db.Products.Where(x => x.Status == true && x.Barcode == Barcode).FirstOrDefault();
            return data;
        }

        public List<SaleUpdateDto> GetRepostory(int id)
        {
            var query = from sl in db.SaleDetails
                        join s in db.Sales on sl.SaleId equals s.Id
                        join p in db.Products on sl.ProductId equals p.Id
                        join c in db.Cards on s.PayType equals c.Id
                        join pl in db.Places on s.PlaceId equals pl.Id
                        join com in db.Companies on s.CustomerId equals com.Id
                        where sl.Id == id
                        select new SaleUpdateDto
                        {
                            Id = sl.Id,
                            ProductName = p.Name,
                            ProductId = p.Id,
                            Barcode = p.Barcode,
                            PayTypeText = c.Text,
                            Discount = sl.DisCount,
                            PlaceName = pl.Name,
                            Quantity = sl.Quantity,
                            Volume = sl.Volume,
                            Price = sl.Price,
                            Total = sl.Total,
                            PayType = s.PayType,
                            PlaceId = s.PlaceId,
                            DocNo = s.DocNo,
                            Date = s.Date,
                            CustomerId = s.CustomerId,
                            CustomerName = com.Name




                        };
            var data = query.ToList();
            return data;
        }


        public void SaleDetailUpdate(SalesDto data)
        {

            var d = data.SaleDetails[0];
            var ds = data.SaleInfo;

            var sd = db.SaleDetails.FirstOrDefault(x => x.Id == d.Id);
            var s = db.Sales.FirstOrDefault(x => x.Id == sd.SaleId);
            var product = db.Products.FirstOrDefault(x => x.Name == d.ProductName);
            sd.SaleId = s.Id;
            sd.ProductId = product.Id;
            sd.Quantity = d.Quantity;
            sd.DisCount = d.DisCount;
            sd.Volume = d.Volume;
            sd.Price = d.Price;
            sd.Total = d.Total;
            s.PayType = ds.PayType;
            s.PlaceId = ds.PlaceId;
            s.DocNo = ds.DocNo;
            s.Date = ds.Date;
            s.CustomerId = ds.CustomerId;


            db.SaleDetails.Update(sd);
            db.Sales.Update(s);


            db.SaveChanges();
        }
    }
}
