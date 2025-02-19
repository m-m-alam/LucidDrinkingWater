using AutoMapper;
using Lucid.Services.Abstractions;
using Lucid.Web.Models;
using Lucid.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lucid.Web.Controllers
{
    public class StockController : Controller
    {        
        private readonly IStockService _service;
        private readonly IMapper _mapper;
        public StockController(IStockService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        public IActionResult Index()
        {
            var entities = _service.GetAll(null,x=>x.Product).ToList();
            var models = _mapper.Map<List<ListStockVm>>(entities);
            return View(models);
        }
    }
}
