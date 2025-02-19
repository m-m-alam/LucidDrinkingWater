using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Lucid.Web.Models.Customer;
using Lucid.Services.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lucid.Models;
using Lucid.Services;
using Lucid.Web.Services;
using Lucid.Web.Models.CustomerTypes;
using Microsoft.EntityFrameworkCore;

namespace Lucid.Web.Controllers
{
    public class CustomerController : Controller//,IDisposable
    {
        private readonly ICustomerService _service;
        private readonly IVanService _vanService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService service, IMapper mapper, IVanService vanService, ICurrentUserService currentUserService)
        {
            _service = service;
            _mapper = mapper;
            _vanService = vanService;
            _currentUserService = currentUserService;
        }

        public IActionResult Index()
        {
            var customers = _service.GetAll().ToList();
            var customerVm = _mapper.Map<List<CustomerListVm>>(customers);
            return View(customerVm);
        }
        public IActionResult Create()
        {
            try
            {
                var model = new CustomerCreateVm();
                model.VanSelectList = new SelectList(_vanService.GetAll().ToList(), "Id", "Name");
                model.LastSaleDate = DateTime.Now;
                return View(model);
            }
            catch (Exception ex) 
            {
                return View();
            }
            

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerCreateVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = _service.IsExists(x => (x.Name == model.CustomerNo || x.Mobile == model.Mobile));
                    if (isExist)
                    {
                        TempData["existModel"] = "Customer Already Exist";
                        return View(model);
                    }
                    var entity = _mapper.Map<Customer>(model);
                    entity.CreatedBy = _currentUserService.UserId;
                    entity.CreatedOn = DateTime.Now;
                    _service.Add(entity);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

            }        
            model.VanSelectList = new SelectList(_vanService.GetAll().ToList(), "Id", "Name");
            return View(model);
        }
         public IActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var entity = _service.GetById((int)id);

                if (entity == null)
                {
                    return NotFound();
                }

                var model = _mapper.Map<CustomerEditVm>(entity);
                model.VanSelectList = new SelectList(_vanService.GetAll().ToList(), "Id", "Name");
                
                
                return View(model);
            }
            catch (Exception ex) { }

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerEditVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = _service.IsExists(x => ((x.Name == model.CustomerNo || x.Mobile == model.Mobile)&& x.Id!=model.Id));
                    if (isExist)
                    {
                        TempData["existModel"] = "Customer Already Exist";
                        return View(model);
                    }
                    var entity = _mapper.Map<Customer>(model);
                    entity.CreatedBy = _currentUserService.UserId;
                    entity.CreatedOn = DateTime.Now;
                    _service.Update(entity);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

            }        
            model.VanSelectList = new SelectList(_vanService.GetAll().ToList(), "Id", "Name");
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _service.GetById(id);
            //if (entity != null)
            //{
            //    entity.IsDeleted = true;
            //    _vanService.Update(entity);
            //}
            _service.Delete(entity);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var customer = _service.GetById(id);
            return Json(customer);
        }
    }
}
