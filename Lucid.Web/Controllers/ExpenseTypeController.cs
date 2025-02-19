using AutoMapper;
using Lucid.Models;
using Lucid.Services.Abstractions;
using Lucid.Services.VanServices;
using Lucid.Web.Models.ExpenseModels;
using Lucid.Web.Models.ExpenseTypeModels;
using Lucid.Web.Models.ProductModels;
using Lucid.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lucid.Web.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly IExpenseTypeService _service;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public ExpenseTypeController(IExpenseTypeService service, IMapper mapper, ICurrentUserService currentUserService)
        {
            _service = service;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public IActionResult Index()
        {
            try
            {
                var entities = _service.GetAll().ToList();
                var models = _mapper.Map<List<ListExpenseTypeVm>>(entities);
                return View(models);
            }
            catch(Exception ex)
            {
                return View();
            }


        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateExpenseTypeVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isExist = _service.IsExists(x => x.Name == model.Name);
                    if (isExist)
                    {
                        TempData["existModel"] = "Expense Type Already Exist";
                        return View(model);
                    }
                    var entity = _mapper.Map<ExpenseType>(model);
                    entity.CreatedBy = _currentUserService.UserId;
                    entity.CreatedOn = DateTime.Now;
                    _service.Add(entity);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex) { }
            return View(model);
        }
        public IActionResult Edit(int? id)
        {            
            try
            {
                if (id == null) return NotFound();
                var entity = _service.GetById((int)id);
                if (entity == null) return NotFound();
                var model = _mapper.Map<EditExpenseTypeVm>(entity);
                return View(model);
            }catch (Exception ex) 
            {
                return NotFound();
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, EditExpenseTypeVm model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var isExist = _service.IsExists(x => x.Name == model.Name && x.Id!=id);
                    if (isExist)
                    {
                        TempData["existModel"] = "Expense Type Already Exist";
                        return View(model);
                    }
                    var entity = _mapper.Map<ExpenseType>(model);
                    entity.LastModifiedBy = _currentUserService.UserId;
                    entity.LastModifiedOn = DateTime.Now;
                    _service.Update(entity);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            var entity = _service.GetById((int)id);           
            _service.Delete(entity);
            return RedirectToAction(nameof(Index));
        }

    }
}
