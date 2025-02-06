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
using Lucid.Web.Models.VanModels;
using Microsoft.AspNetCore.Authorization;

namespace Lucid.Web.Controllers
{
    [Authorize]
    public class VansController : Controller
    {
        private readonly IVanService _vanService;
        private readonly IMapper _mapper;
        protected readonly ICurrentUserService _currentUserService;

        public VansController(IVanService vanService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _vanService = vanService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        // GET: Vans
        public IActionResult Index()
        {
            var entities = _vanService.GetAll().ToList();
            var models = _mapper.Map<List<VanListVm>>(entities);
            return View(models);
        }

        // GET: Vans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var van =  _vanService.GetById((int)id);
            if (van == null)
            {
                return NotFound();
            }

            return View(van);
        }

        // GET: Vans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vans/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VanCreateVm van)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<Van>(van);
                entity.CreatedBy = _currentUserService.UserId;
                entity.CreatedOn = DateTime.Now;
                _vanService.Add(entity);                
                return RedirectToAction(nameof(Index));
            }
            return View(van);
        }

        //// GET: Vans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity =  _vanService.GetById((int)id);

            if (entity == null)
            {
                return NotFound();
            }

            var entityVm = _mapper.Map<VanEditVm>(entity);           
            return View(entityVm);
        }

        // POST: Vans/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VanEditVm model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = _mapper.Map<Van>(model);
                    entity.LastModifiedBy = _currentUserService.UserId;
                    entity.LastModifiedOn = DateTime.Now;
                    _vanService.Update(entity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // POST: Vans/Delete/5
        [HttpGet]        
        public IActionResult Delete(int id)
        {
            var entity = _vanService.GetById(id);
            //if (entity != null)
            //{
            //    entity.IsDeleted = true;
            //    _vanService.Update(entity);
            //}
            _vanService.Delete(entity);
            return RedirectToAction(nameof(Index));
        }

        //private bool VanExists(int id)
        //{
        //    return _context.Vans.Any(e => e.Id == id);
        //}
    }
}
