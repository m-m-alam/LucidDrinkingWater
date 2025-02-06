using AutoMapper;
using Lucid.Models;
using Lucid.Services.Abstractions;
using Lucid.Web.Models.Sales;
using Lucid.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lucid.Web.Controllers
{
    public class SaleController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly ISaleService _service;
        private readonly IPaymentService _paymentService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public SaleController(ISaleService service, ICustomerService customerService, IMapper mapper, IProductService productService, ICurrentUserService currentUserService, IPaymentService paymentService)
        {
            _service = service;
            _mapper = mapper;
            _productService = productService;
            _customerService = customerService;
            _currentUserService = currentUserService;
            _paymentService = paymentService;
        }
        public IActionResult Index()
        {
            var entities = _service.GetAllCurrentDate().ToList();
            var models = _mapper.Map<List<ListSaleVm>>(entities);
            return View(models);
        }
        public IActionResult Create()
        {
            var model = new CreateSaleVm();
            model.Customers = new SelectList(_customerService.GetAll().ToList(), "Id", "Name");
            model.Products = new SelectList(_productService.GetAll().ToList(), "Id", "Name");
            model.SaleDate = DateTime.Now;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateSaleVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var saleDetails = _mapper.Map<List<SaleDetails>>(model.SaleDetails);
                    var entity = _mapper.Map<Sale>(model);
                    entity.SaleDetails = saleDetails;
                    entity.CreatedBy = _currentUserService.UserId;
                    entity.CreatedOn = DateTime.Now;
                    _service.Add(entity);

                    var customer = _customerService.GetById(model.CustomerId);
                    customer.DueAmount = (customer.DueAmount + (model.TotalAmount - (model.Discount.GetValueOrDefault() + model.Payment.GetValueOrDefault())));
                    foreach (var item in model.SaleDetails)
                    {
                        var product = _productService.GetById(item.ProductId);
                        if (product.Name == "Water Jar")
                        {
                            customer.StockJar = item.Stock.GetValueOrDefault();
                            customer.LastSaleDate = model.SaleDate;
                        }
                    }
                    if (model.Payment > 0)
                    {
                        var payment = new Payment()
                        {
                            Amount = (double)model.Payment,
                            PaymentDate = model.SaleDate,
                            CustomerId = model.CustomerId,
                            CreatedBy = _currentUserService.UserId,
                            CreatedOn = DateTime.Now,
                        };

                        _paymentService.Add(payment);
                    }
                    _customerService.Update(customer);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex) 
            { 
            }

            model.Customers = new SelectList(_customerService.GetAll().ToList(), "Id", "Name");
            model.Products = new SelectList(_productService.GetAll().ToList(), "Id", "Name");
            model.SaleDate = DateTime.Now;
            return View(model);
        }
        public IActionResult Edit()
        {
            return View();
        }

       
    }
}
