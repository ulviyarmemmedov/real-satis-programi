using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.AddDTOs;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Dtos.SaleDTOs;
using SparePartsSale.WebApp.Infrastructure.DataAccess.Entities.Models;
using SparePartsSale.WebApp.Infrastructure.Repositories;
using SparePartsSale.WebApp.Infrastructure.Repositories.AddRepository;
using SparePartsSale.WebApp.Infrastructure.Repositories.SaleRepositorys;
using SparePartsSale.WebApp.Models.AddVMs;
using SparePartsSale.WebApp.Models.SaleVMs;

namespace SparePartsSale.WebApp.Controllers
{
    public class AddController : Controller
    {
        GeneralRepository generalRepository = new GeneralRepository();
        SaleRepository saleRepository = new SaleRepository();
        AddRepostory addRepostory = new AddRepostory();
        AddUpdateRepostory addUpdateRepostory = new AddUpdateRepostory();
        int UserId = 1;
        public IActionResult AddProduct()
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
            saleAddViewModel.SaleDetail = new List<SaleDetail> { new SaleDetail() };
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
        public IActionResult AddProduct([FromBody] AddDto data)
        {
            addRepostory.AddWarehouseDoc(data.addInfo);
            addRepostory.AddWarehouseDocDetail(data.addDetails);


            var result = new
            {
                status = "success",
                redirect_url = "/add/addreport"
            };

            return Json(result);

        }
        public IActionResult AddReport()
        {


            AddReportVm vm = new AddReportVm()
            {

                Report = addRepostory.AddReport()

            };


            return View(vm);
        }
        public IActionResult delete(int id)
        {
            ViewBag.id = id;
            return View();
        }
        public IActionResult AddDelete(int? id)
        {
            if (id == null) return NotFound();
            addRepostory.Delete(id.Value);
            return RedirectToAction("addreport");
        }
        public IActionResult AddUpdate(int? id)
        {
            AddUpdateVm addUpdateVM = new AddUpdateVm();
            var Company = addUpdateRepostory.GetCompany(0, id.Value);
            var PayType = addUpdateRepostory.GetCard("PayType", id.Value);
            var Place = addUpdateRepostory.GetPlace(UserId, id.Value);
            var DocNo = addUpdateRepostory.GetDocNo(UserId);

            addUpdateVM.CompanyList = new List<SelectListItem>();
            addUpdateVM.PlaceList = new List<SelectListItem>();
            addUpdateVM.PayTypeList = new List<SelectListItem>();
            addUpdateVM.Product = addUpdateRepostory.GetRepostory(id.Value);

            addUpdateVM.WarehouseDocs = new WarehouseDoc() { DocNo = DocNo, Date = DateTime.Now, PlaceId = 1 };
            addUpdateVM.WarehouseDocDetails = new List<WarehouseDocDetail> { new WarehouseDocDetail() };
            foreach (var item in Company)
            {
                addUpdateVM.CompanyList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            foreach (var item in PayType)
            {
                addUpdateVM.PayTypeList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Text });
            }
            foreach (var item in Place)
            {
                addUpdateVM.PlaceList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }

            return View(addUpdateVM);


        }
        [HttpPost]
        public IActionResult AddUpdate([FromBody] AddDto data)
        {

            addUpdateRepostory.AddDetailUpdate(data);


            var result = new
            {
                status = "success",
                redirect_url = "/add/addreport"
            };

            return Json(result);

        }
    }
}
