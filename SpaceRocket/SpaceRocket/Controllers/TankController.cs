using Microsoft.AspNetCore.Mvc;
using SpaceRocket.Data.Entitys;
using SpaceRocket.Models.EditViewModels;
using SpaceRocket.Models;
using SpaseRocket.Data;
using Microsoft.EntityFrameworkCore;

namespace SpaceRocket.Controllers
{
    public class TankController : Controller
    {

        private readonly DataContext _context;
        public TankController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var tank = _context.Tank.ToList();
            var viewModel = new TankViewModel()
            {
                Tanks = tank
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TankViewModel tankRequest)
        {
            if (ModelState.IsValid)
            {
                var tank = new Tank()
                {
                    Id = Guid.NewGuid(),
                    Name = tankRequest.Name,
                    Capacity = tankRequest.Capacity,
                    Weight = tankRequest.Weight
                };
                await _context.Tank.AddAsync(tank);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var tank = await _context.Tank.FirstOrDefaultAsync(x => x.Id == id);
            if (tank != null)
            {
                var viewModel = new EditTankViewModel()
                {
                    Id = tank.Id,
                    Name = tank.Name,
                    Capacity = tank.Capacity,
                    Weight = tank.Weight
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> View(EditTankViewModel editRequest)
        {
            var tank = await _context.Tank.FindAsync(editRequest.Id);
            if (tank != null)
            {
                tank.Name = editRequest.Name;
                tank.Capacity = editRequest.Capacity;
                tank.Weight = editRequest.Weight;

                await _context.SaveChangesAsync();
                return RedirectToAction("Add");
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTankViewModel deletRequest)
        {
            var tank = _context.Tank.Find(deletRequest.Id);
            if (tank != null)
            {
                _context.Tank.Remove(tank);
                await _context.SaveChangesAsync();
                return RedirectToAction("Add");
            }
            return RedirectToAction("Add");
        }
    }
}

