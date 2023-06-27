using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.SaleDTOs;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models;
using SparePartsSale.WebApp.Infrastructure.DataAccess.EntityFramework.Contexts;


namespace SparePartsSale.WebApp.Infrastructure.Repositories.SaleRepositorys
{
    public class SaleRepository
    {
        SaleAppDbContext db;
        public SaleRepository()
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

        public IQueryable<Card> GetCard(string type)
        {
            var data = db.Cards.Where(x => x.Type == type && x.Status == true).OrderBy(x => x.Text);
            return data;
        }

        public void AddSale(Sale data)
        {
            db.Sales.Add(data);
            db.SaveChanges();
        }

        public void AddSaleDetail(List<SaleDetailDto> data)
        {
            foreach (var item in data)
            {
                var latestSale = db.Sales.OrderByDescending(s => s.Id).FirstOrDefault();

                var SerachData = db.Products.FirstOrDefault(x => x.Name == item.ProductName);
                SaleDetail ob = new SaleDetail()
                {
                    SaleId = latestSale.Id,
                    ProductId = SerachData.Id,
                    Quantity = item.Quantity,
                    Volume = item.Volume,
                    Price = item.Price,
                    Total = item.Total,
                    DisCount = item.DisCount



                };

                db.SaleDetails.Add(ob);
            }
            db.SaveChanges();
        }

        public List<ReportDto> Report()
        {


            var query = from sd in db.SaleDetails
                        join pr in db.Products on sd.ProductId equals pr.Id
                        join s in db.Sales on sd.SaleId equals s.Id into saleGroup
                        from sale in saleGroup.DefaultIfEmpty()
                        join p in db.Places on sale != null ? sale.PlaceId : null equals p.Id into placeGroup
                        from place in placeGroup.DefaultIfEmpty()
                        join pay in db.Cards on sale != null ? sale.PayType : null equals pay.Id into cardGroup
                        from card in cardGroup.DefaultIfEmpty()
                        join c in db.Companies on sale != null ? sale.CustomerId : null equals c.Id into companyGroup
                        from company in companyGroup.DefaultIfEmpty()
                        select new ReportDto
                        {
                            Id = sd.Id,


                            Total = sd.Total,
                            PayType = card.Text,
                            Discount = sd.DisCount,
                            Place = place.Name,
                            DocNo = sale != null ? sale.DocNo : null,
                            Date = sale != null ? sale.Date : null,
                            Customer = company.Name
                        };

            var list = query.OrderByDescending(x => x.Id).ToList();
            return list;
        }

        public void Delete(int id)
        {
            var SaleDetailItem = db.SaleDetails.FirstOrDefault(s => s.Id == id);
            var SaleItem = db.Sales.FirstOrDefault(x => x.Id == SaleDetailItem.SaleId);
            var data = db.SaleDetails.Where(x => x.SaleId == SaleItem.Id).ToList();

            db.SaleDetails.Remove(SaleDetailItem);
            if (data.Count() == 1)
            {
                db.Sales.Remove(SaleItem);
            }
            db.SaveChanges();
        }



    }
}
