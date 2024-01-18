using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using SpaceRocket.Data.Entitys;
using SpaceRocket.Models;
using SpaceRocket.Models.EditViewModels;
using SpaseRocket.Data;

namespace SpaceRocket.Controllers
{
    public class EngineController : Controller
    {
        private readonly DataContext _context;
        public EngineController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var engines = _context.Engine.ToList();
            var fuels = _context.Fuel.ToList();
            var viewModel = new EngineViewModel()
            {
                Engines = engines,
                Fuels = fuels
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EngineViewModel engineRequest)
        {
            var fuels = _context.Fuel.ToList();
            
            if (fuels != null) 
            {
                engineRequest.Fuels.AddRange(fuels);
                if (ModelState.IsValid)
                {
                    var fuel = engineRequest.Fuels.FirstOrDefault(o => o.Name == engineRequest.FuelType);
                    var engine = new Engine()
                    {
                        Id = Guid.NewGuid(),
                        Name = engineRequest.Name,
                        FuelType = fuel,
                        Thrust = engineRequest.Thrust,
                        Weight = engineRequest.Weight
                    };
                    await _context.Engine.AddAsync(engine);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var engine = await _context.Engine.FirstOrDefaultAsync(x => x.Id == id);
            var fuels = await _context.Fuel.ToListAsync();
            if (engine != null)
            {

                var viewModel = new EditEngineViewModel()
                {
                    Id = engine.Id,
                    Name = engine.Name,
                    FuelType = engine.FuelType.Name,
                    Thrust = engine.Thrust,
                    Weight = engine.Weight,
                    Fuels = fuels
                    
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> View(EditEngineViewModel editRequest)
        {
            var engine = await _context.Engine.FindAsync(editRequest.Id);
            var fuels = _context.Fuel.ToList();
            if (engine != null)
            {
                if (fuels != null)
                {
                    editRequest.Fuels = new List<Fuel>();
                    editRequest.Fuels.AddRange(fuels);
                    var fuel = editRequest.Fuels.FirstOrDefault(o => o.Name == editRequest.FuelType);

                    engine.Name = editRequest.Name;
                    engine.FuelType = fuel;
                    engine.Thrust = editRequest.Thrust;
                    engine.Weight = editRequest.Weight;

                    await _context.SaveChangesAsync();
                    return RedirectToAction("Add");
                } 
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditEngineViewModel deletRequest)
        {
            var engine = _context.Engine.Find(deletRequest.Id);
            if (engine != null)
            {
                _context.Engine.Remove(engine);
                await _context.SaveChangesAsync();
                return RedirectToAction("Add");
            }
            return RedirectToAction("Add");
        }
    }
}
