using AutoMapper;
using Lucid.Services.Abstractions;
using Lucid.Web.Models.ExpenseModels;
using Lucid.Web.Models.ProductModels;
using Lucid.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lucid.Web.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseTypeService _expenseTypeService;
        private readonly IExpenseService _service;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public ExpenseController(IExpenseTypeService expenseTypeService, IExpenseService service, IMapper mapper, IVanService vanService, ICurrentUserService currentUserService)
        {
            _expenseTypeService = expenseTypeService;
            _mapper = mapper;
            _service = service;
            _currentUserService = currentUserService;
        }
        public IActionResult Index()
        {
            var entity = _service.GetAll().ToList();
            var model = _mapper.Map<List<ListExpenseVm>>(entity);
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new CreateExpenseVm();
            model.ExpenseTypeSelectList = new SelectList(_expenseTypeService.GetAll().ToList(), "Id", "Name");
            model.ExpenseDate = DateTime.Now;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateExpenseVm model)
        {
            return View();
        }
        public IActionResult Edit(int? id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, EditExpenseVm model)
        {
            return View();
        }


        public IActionResult Delete(int? id)
        {
            return View();
        }
    }
}
