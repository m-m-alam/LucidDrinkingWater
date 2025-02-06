using AutoMapper;
using Lucid.Models;
using Lucid.Services.Abstractions;
using Lucid.Services.VanServices;
using Lucid.Web.Models.Customer;
using Lucid.Web.Models.CustomerTypes;
using Lucid.Web.Models.VanModels;
using Lucid.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lucid.Web.Controllers
{
    [Authorize]
    public class CustomerTypeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly ICustomerTypeService _service;

        public CustomerTypeController(IMapper mapper, ICurrentUserService currentUserService, ICustomerTypeService service)
        {
            _mapper = mapper;
            _currentUserService = currentUserService;
            _service = service;
        }

        public IActionResult Index()
        {
            var entities = _service.GetAll();
            var models = _mapper.Map<List<CustomerTypeListVm>>(entities);
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerTypeCreateVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    var entity = _mapper.Map<CustomerType>(model);                   
                    entity.CreatedBy = _currentUserService.UserId;
                    entity.CreatedOn = DateTime.Now;
                    _service.Add(entity);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex) 
            { 

            }
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

                var entityVm = _mapper.Map<CustomerTypeEditVm>(entity);
                return View(entityVm);
            }
            catch (Exception ex) { }
          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerTypeEditVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    var entity = _mapper.Map<CustomerType>(model);                   
                    entity.LastModifiedBy = _currentUserService.UserId;
                    entity.LastModifiedOn = DateTime.Now;
                    _service.Update(entity);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex) 
            { 

            }
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

    }
}
