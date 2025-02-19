using AutoMapper;
using Lucid.Models;
using Lucid.Services.Abstractions;
using Lucid.Web.Models.PurchaseModels;
using Lucid.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lucid.Web.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _service;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IStockService _stockService;


        public PurchaseController(IPurchaseService service, IProductService productService, IMapper mapper, ICurrentUserService currentUserService, IStockService stockService)
        {
            _productService = productService;
            _service = service;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _stockService = stockService;
        }
        public IActionResult Index()
        {
            var entities = _service.GetAll();
            var models = _mapper.Map<List<ListPurchaseVm>>(entities);
            return View(models);
        }
        public IActionResult Create()
        {
            var model = new CreatePurchaseVm();
            model.Products = new SelectList(_productService.GetAll(), "Id", "Name");
            model.PurchaseDate = DateTime.Now;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePurchaseVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var purchaseDetails = _mapper.Map<List<PurchaseDetails>>(model.PurchaseDetails);
                    var entity = _mapper.Map<Purchase>(model);
                    entity.PurchaseDetails = purchaseDetails;
                    entity.CreatedBy = _currentUserService.UserId;
                    entity.CreatedOn = DateTime.Now;
                    _service.Add(entity);

                    
                    foreach (var item in purchaseDetails)
                    {
                        var productStock = _stockService.GetById(item.ProductId);
                        if (productStock == null)
                        {
                            var newProductStock = new Stock() { ProductId = item.ProductId , Quantity = item.Quantity };
                            _stockService.Add(newProductStock);
                        }
                        else
                        {
                            productStock.Quantity += item.Quantity;
                            _stockService.Update(productStock);
                        }
                    }                                     

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
            }

            model.Products = new SelectList(_productService.GetAll(), "Id", "Name");
            model.PurchaseDate = DateTime.Now;
            return View(model);
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditPurchaseVm model)
        {
            return View();
        }


    }
}
