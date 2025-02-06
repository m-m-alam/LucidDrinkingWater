using AutoMapper;
using Lucid.Models;
using Lucid.Services.Abstractions;
using Lucid.Web.Models.ExpenseModels;
using Lucid.Web.Models.ExpenseTypeModels;
using Lucid.Web.Models.ProductModels;
using Lucid.Web.Services;
using Microsoft.AspNetCore.Mvc;

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
            catch
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
            return View();
        }
        public IActionResult Delete(int? id)
        {
            return View();
        }

    }
}
