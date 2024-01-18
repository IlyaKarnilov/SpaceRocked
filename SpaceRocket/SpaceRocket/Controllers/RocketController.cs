using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceRocket.Data.Entitys;
using SpaceRocket.Models;
using SpaceRocket.Models.EditViewModels;
using SpaseRocket.Data;
using System.Xml.Linq;

namespace SpaceRocket.Controllers
{
    public class RocketController : Controller
    {
        private readonly DataContext _context;
        public RocketController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var rockets = _context.Rocket.ToList();
            var engines = _context.Engine.Include(e => e.FuelType).ToList();
            var heads = _context.HeadModule.ToList();
            var tanks = _context.Tank.ToList();
            var viewModel = new RocketViewModel() 
            {
                Rockets = rockets,
                Engines = engines,
                HeadModules = heads,
                Tanks = tanks
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RocketViewModel rocketRequest)
        {
            var engines = _context.Engine.Include(e => e.FuelType).ToList();
            var heads = _context.HeadModule.ToList();
            var tanks = _context.Tank.ToList();

            if (engines != null && heads != null && tanks != null)
            {
                rocketRequest.Engines.AddRange(engines);
                rocketRequest.HeadModules.AddRange(heads);
                rocketRequest.Tanks.AddRange(tanks);
                if (ModelState.IsValid)
                {
                    var rocket = new Rocket()
                    {
                        Id = Guid.NewGuid(),
                        Name = rocketRequest.Name,
                        HeadModule = rocketRequest.HeadModules.FirstOrDefault(o => o.Name == rocketRequest.HeadModuleName),
                        Tank = rocketRequest.Tanks.FirstOrDefault(o => o.Name == rocketRequest.TankName),
                        Engine = rocketRequest.Engines.FirstOrDefault(o => o.Name == rocketRequest.EngineName),
                        LaunchDate = rocketRequest.LaunchDate.ToUniversalTime(),
                        ReturnDate = rocketRequest.ReturnDate.ToUniversalTime()
                    };
                    await _context.Rocket.AddAsync(rocket);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var rocket = await _context.Rocket.FirstOrDefaultAsync(x => x.Id == id);
            var engines = _context.Engine.Include(e => e.FuelType).ToList();
            var heads = _context.HeadModule.ToList();
            var tanks = _context.Tank.ToList();
            if (rocket != null)
            {

                var viewModel = new EditRocketViewModel()
                {
                    Id = rocket.Id,
                    Name = rocket.Name,
                    EngineName = rocket.Engine.Name,
                    HeadModuleName = rocket.HeadModule.Name,
                    TankName = rocket.Tank.Name,
                    LaunchDate = rocket.LaunchDate.ToUniversalTime(),
                    ReturnDate = rocket.ReturnDate.ToUniversalTime(),
                    Engines = engines,
                    HeadModules = heads,
                    Tanks = tanks
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> View(EditRocketViewModel editRequest)
        {
            var rocket = await _context.Rocket.FindAsync(editRequest.Id);
            var engines = _context.Engine.Include(e => e.FuelType).ToList();
            var heads = _context.HeadModule.ToList();
            var tanks = _context.Tank.ToList();
            if (rocket != null)
            {
                if (engines != null && heads != null && tanks != null)
                {
                    editRequest.Engines.AddRange(engines);
                    editRequest.HeadModules.AddRange(heads);
                    editRequest.Tanks.AddRange(tanks);

                    rocket.Name = editRequest.Name;
                    rocket.HeadModule = editRequest.HeadModules.FirstOrDefault(o => o.Name == editRequest.HeadModuleName);
                    rocket.Tank = editRequest.Tanks.FirstOrDefault(o => o.Name == editRequest.TankName);
                    rocket.Engine = editRequest.Engines.FirstOrDefault(o => o.Name == editRequest.EngineName);
                    rocket.LaunchDate = editRequest.LaunchDate.ToUniversalTime();
                    rocket.ReturnDate = editRequest.ReturnDate.ToUniversalTime();

                    await _context.SaveChangesAsync();
                    return RedirectToAction("Add");
                }
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditRocketViewModel deletRequest)
        {
            var rocket = _context.Rocket.Find(deletRequest.Id);
            if (rocket != null)
            {
                _context.Rocket.Remove(rocket);
                await _context.SaveChangesAsync();
                return RedirectToAction("Add");
            }
            return RedirectToAction("Add");
        }
    }
}
