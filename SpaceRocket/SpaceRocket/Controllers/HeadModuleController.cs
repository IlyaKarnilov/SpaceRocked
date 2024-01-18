using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceRocket.Data.Entitys;
using SpaceRocket.Models;
using SpaceRocket.Models.EditViewModels;
using SpaseRocket.Data;

namespace SpaceRocket.Controllers
{
    public class HeadModuleController : Controller
    {
        private readonly DataContext _context;
        public HeadModuleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var headModules = _context.HeadModule.ToList();
            var viewModel = new HeadModuleViewModel()
            {
                headModules = headModules
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HeadModuleViewModel headModuleRequest) 
        {
            if (ModelState.IsValid)
            {
                var headModule = new HeadModule()
                {
                    Id = Guid.NewGuid(),
                    Name = headModuleRequest.Name,
                    CrewCount = headModuleRequest.CrewCount,
                    Weight = headModuleRequest.Weight
                };
                await _context.HeadModule.AddAsync(headModule);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var headModule = await _context.HeadModule.FirstOrDefaultAsync(x => x.Id == id);
            if (headModule != null)
            {
                var viewModel = new EditHeadModuleViewModel()
                {
                    Id = headModule.Id,
                    Name = headModule.Name,
                    CrewCount = headModule.CrewCount,
                    Weight = headModule.Weight
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> View(EditHeadModuleViewModel editRequest) 
        {
            var headModule = await _context.HeadModule.FindAsync(editRequest.Id);
            if (headModule != null)
            {
                headModule.Name = editRequest.Name;
                headModule.CrewCount = editRequest.CrewCount;
                headModule.Weight = editRequest.Weight;

                await _context.SaveChangesAsync();
                return RedirectToAction("Add");
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditHeadModuleViewModel deletRequest) 
        {
            var headModule = _context.HeadModule.Find(deletRequest.Id);
            if (headModule != null) 
            {
                _context.HeadModule.Remove(headModule);
                await _context.SaveChangesAsync();
                return RedirectToAction("Add");
            }
            return RedirectToAction("Add");
        }
    }
}
