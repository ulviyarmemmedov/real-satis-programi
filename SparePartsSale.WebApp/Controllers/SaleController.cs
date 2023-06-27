using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.SaleDTOs;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models;
using SparePartsSale.WebApp.Infrastructure.Repositories;
using SparePartsSale.WebApp.Infrastructure.Repositories.SaleRepositorys;
using SparePartsSale.WebApp.Models.SaleVMs;

namespace SparePartsSale.WebApp.Controllers
{
    public class SaleController : Controller
    {

        GeneralRepository generalRepository = new GeneralRepository();
        SaleRepository saleRepository = new SaleRepository();
        SaleUpdateRepositery saleUpdateRepositery = new SaleUpdateRepositery();
        int UserId = 1;
        public IActionResult Add()
        {
            SaleAddViewModel saleAddViewModel = new SaleAddViewModel();
            var Company = generalRepository.GetCompany(0);
            var PayType = generalRepository.GetCard("PayType");
            var Place = generalRepository.GetPlace(UserId);
            var DocNo = saleRepository.GetDocNo(UserId);

            saleAddViewModel.CompanyList = new List<SelectListItem>();
            saleAddViewModel.PlaceList = new List<SelectListItem>();
            saleAddViewModel.PayTypeList = new List<SelectListItem>();

            saleAddViewModel.Sale = new Sale() { DocNo = DocNo, Date = DateTime.Now, PlaceId = 1 };
            saleAddViewModel.SaleDetail=new List<SaleDetail> { new SaleDetail() };
            foreach (var item in Company)
            {
                saleAddViewModel.CompanyList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            foreach (var item in PayType)
            {
                saleAddViewModel.PayTypeList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Text });
            }
            foreach (var item in Place)
            {
                saleAddViewModel.PlaceList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }

            return View(saleAddViewModel);
        }


        [HttpPost]
        public IActionResult Add([FromBody] SalesDto data)
        {
            saleRepository.AddSale(data.SaleInfo);
            saleRepository.AddSaleDetail(data.SaleDetails);


            var result = new
            {
                status = "success",
                redirect_url = "/sale/report"
            };

            return Json(result);

        }

        public IActionResult GetProduct(string Barcode)
        {
            var data = generalRepository.GetProduct(Barcode);
            return Ok(data);
        }
        public IActionResult Report()
        {


            ReportVM vm = new ReportVM() {

                Report = saleRepository.Report()

            };

           
            return View(vm);
        }
        public IActionResult DeleteSale(int? id)
        {
            if (id == null) return NotFound();
            saleRepository.Delete(id.Value);
            return RedirectToAction("report");
        }
        public IActionResult UpdateSale(int? id)
        {
            UpdateSaleVM UpdateSaleVM = new UpdateSaleVM();
            var Company = saleUpdateRepositery.GetCompany(0,id.Value);
            var PayType = saleUpdateRepositery.GetCard("PayType", id.Value);
            var Place = saleUpdateRepositery.GetPlace(UserId,  id.Value);
            var DocNo = saleUpdateRepositery.GetDocNo(UserId);
            
            UpdateSaleVM.CompanyList = new List<SelectListItem>();
            UpdateSaleVM.PlaceList = new List<SelectListItem>();
            UpdateSaleVM.PayTypeList = new List<SelectListItem>();
            UpdateSaleVM.Product = saleUpdateRepositery.GetRepostory(id.Value);

            UpdateSaleVM.Sale = new Sale() { DocNo = DocNo, Date = DateTime.Now, PlaceId = 1 };
            UpdateSaleVM.SaleDetail = new List<SaleDetail> { new SaleDetail() };
            foreach (var item in Company)
            {
                UpdateSaleVM.CompanyList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            foreach (var item in PayType)
            {
                UpdateSaleVM.PayTypeList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Text });
            }
            foreach (var item in Place)
            {
                UpdateSaleVM.PlaceList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }

            return View(UpdateSaleVM);


        }
        [HttpPost]
        public IActionResult UpdateSale([FromBody] SalesDto data)
        {
           
            saleUpdateRepositery.SaleDetailUpdate(data);


            var result = new
            {
                status = "success",
                redirect_url = "/sale/report"
            };

            return Json(result);

        }
        public IActionResult delete(int id)
        {
            ViewBag.id = id;
            return View();
        }



    }

  



}
