using AutoMapper;
using Lucid.Models;
using Lucid.Services.Abstractions;
using Lucid.Services.ProductServices;
using Lucid.Services.VanServices;
using Lucid.Web.Models.Customer;
using Lucid.Web.Models.ProductModels;
using Lucid.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lucid.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper, ICurrentUserService currentUserService)
        {
            _service = service;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public IActionResult Index()
        {
            var entites = _service.GetAll().ToList();
            var models = _mapper.Map<List<ListProductVm>>(entites);
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _mapper.Map<Product>(model);
                    entity.CreatedBy = _currentUserService.UserId;
                    entity.CreatedOn = DateTime.Now;
                    _service.Add(entity);
                    return RedirectToAction("Index");
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

                var model = _mapper.Map<EditProductVm>(entity);
                return View(model);
            }
            catch (Exception ex) { }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, EditProductVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _mapper.Map<Product>(model);
                    entity.LastModifiedBy = _currentUserService.UserId;
                    entity.LastModifiedOn = DateTime.Now;
                    _service.Update(entity);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetProducts()
        {
            var products = _service.GetAll()
                //.Select(p => new { Value = p.Id.ToString(), Text = p.Name })
                .ToList();

            return Json(products);
        }
        [HttpGet]
        public JsonResult GetById(int id)
        {
            var product = _service.GetById(id);
            return Json(product);
        }
    }
}
