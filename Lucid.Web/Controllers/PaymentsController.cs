using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lucid.Database;
using Lucid.Models;
using AutoMapper;
using Lucid.Services.Abstractions;
using Lucid.Web.Services;
using Lucid.Web.Models.PaymentModels;

namespace Lucid.Web.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _service;
        private readonly ICustomerService _customerService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _context;

        public PaymentsController(IPaymentService service, ICustomerService customerService, ICurrentUserService currentUserService, IMapper mapper)
        {
            _service = service;
            _customerService = customerService;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var entities =_service.GetAll().ToList();
            var models = _mapper.Map<List<ListPaymentVm>>(entities);
            
            return View(models);
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            var model = new CreatePaymentVm();
            model.Customers = new SelectList(_customerService.GetAll().ToList(), "Id", "Name");
            model.PaymentDate = DateTime.Now;
            return View(model);
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePaymentVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _mapper.Map<Payment>(model);
                    entity.CreatedBy = _currentUserService.UserId;
                    entity.CreatedOn = DateTime.Now;
                    _service.Add(entity);
                    var customer = _customerService.GetById(entity.CustomerId);
                    customer.DueAmount = customer.DueAmount - model.Amount;
                    customer.LastModifiedBy = _currentUserService.UserId;
                    customer.LastModifiedOn = DateTime.Now;
                    _customerService.Update(customer);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex) 
            { 

            }

            model.Customers = new SelectList(_customerService.GetAll().ToList(), "Id", "Name");
            return View(model);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
                var model = _mapper.Map<EditPaymentVm>(entity);
                model.Customers = new SelectList(_customerService.GetAll().ToList(), "Id", "Name");
                return View(model);
            }
            catch (Exception ex) 
            {
                return View();
            }
           
            
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditPaymentVm model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   
                    var entity = _mapper.Map<Payment>(model);
                    double existingPayment = _service.GetById(entity.Id).Amount;
                    entity.LastModifiedBy = _currentUserService.UserId;
                    entity.LastModifiedOn = DateTime.Now;
                    _service.Update(entity);
                    var customer = _customerService.GetById(entity.CustomerId);
                    customer.DueAmount = customer.DueAmount - model.Amount + existingPayment;
                    customer.LastModifiedBy = _currentUserService.UserId;
                    customer.LastModifiedOn = DateTime.Now;
                    _customerService.Update(customer);
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                   
                }
                
            }
            model.Customers = new SelectList(_customerService.GetAll().ToList(), "Id", "Name");
            return View(model);
        }

        // GET: Payments/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    var entity = _service.GetById((int)id);
        //    //if (entity != null)
        //    //{
        //    //    entity.IsDeleted = true;
        //    //    _vanService.Update(entity);
        //    //}
        //    _service.Delete(entity);
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
