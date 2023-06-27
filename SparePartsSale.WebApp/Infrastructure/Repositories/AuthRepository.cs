using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models;
using SparePartsSale.WebApp.Infrastructure.DataAccess.EntityFramework.Contexts;


namespace SparePartsSale.WebApp.Infrastructure.Repositories
{
    public class AuthRepository 
    {
        SaleAppDbContext db;
        public AuthRepository()
        {
            db = new SaleAppDbContext();
        }

        public IQueryable<Menu> GetMenus()
        {
            var data = db.Menus.Where(x => x.Type == 0  && x.Status == true).OrderBy(x => x.Orderby);
            return data;
        }

        public IQueryable<Menu> GetMenus( int ParentId)
        {
            var data = db.Menus.Where(x => x.Type == 1 && x.ParentId == ParentId && x.Status == true).OrderBy(x => x.Orderby);
            return data;
        }

       
    }
}
