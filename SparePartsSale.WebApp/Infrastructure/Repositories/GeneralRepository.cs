using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models;
using SparePartsSale.WebApp.Infrastructure.DataAccess.EntityFramework.Contexts;
using System.Linq;

namespace SparePartsSale.WebApp.Infrastructure.Repositories
{
    public class GeneralRepository
    {
        SaleAppDbContext db;
        public GeneralRepository()
        {
            db = new SaleAppDbContext();
        }

        public IQueryable<Company> GetCompany(byte type)
        {
            var data = db.Companies.Where(x => x.Type==type && x.Status == true).OrderBy(x => x.Name);
            return data;
        }

        public IQueryable<Place> GetPlace(int userId)
        {
            var PlaceId = db.Users.Where(x => x.Id == userId && x.Status == true).FirstOrDefault().PlaceId;

            var data = db.Places.Where(x => x.Id == PlaceId);

            return data;
        }

        public IQueryable<Card> GetCard(string type)
        {
            var data = db.Cards.Where(x => x.Type == type && x.Status == true).OrderBy(x => x.Text);
            return data;
        }

        public Product GetProduct(string Barcode)
        {
            var data = db.Products.Where(x => x.Status == true && x.Barcode == Barcode).FirstOrDefault();
            return data;
        }
    }
}
