using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceRocket.Data.Entitys;
using SpaceRocket.Models;
using SpaceRocket.Models.EditViewModels;
using SpaseRocket.Data;

namespace SpaceRocket.Controllers
{
    public class FuelController : Controller
    {
        private readonly DataContext _context;
        public FuelController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var fuels = _context.Fuel.ToList();
            var viewModel = new FuelViewModel()
            {
                Fuels = fuels
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FuelViewModel FuelRequest)
        {
            if (ModelState.IsValid)
            {
                var fuel = new Fuel()
                {
                    Id = Guid.NewGuid(),
                    Name = FuelRequest.Name,
                    WeightPerCubicMeter = FuelRequest.WeightPerCubicMeter,
                };
                await _context.Fuel.AddAsync(fuel);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var fuel = await _context.Fuel.FirstOrDefaultAsync(x => x.Id == id);
            if (fuel != null)
            {
                var viewModel = new EditFuelViewModel()
                {
                    Id = fuel.Id,
                    Name = fuel.Name,
                    WeightPerCubicMeter= fuel.WeightPerCubicMeter,
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> View(EditFuelViewModel editRequest)
        {
            var fuel = await _context.Fuel.FindAsync(editRequest.Id);
            if (fuel != null)
            {
                fuel.Name = editRequest.Name;
                fuel.WeightPerCubicMeter = editRequest.WeightPerCubicMeter;

                await _context.SaveChangesAsync();
                return RedirectToAction("Add");
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditFuelViewModel deletRequest)
        {
            var fuel = _context.Fuel.Find(deletRequest.Id);
            if (fuel != null)
            {
                _context.Fuel.Remove(fuel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Add");
            }
            return RedirectToAction("Add");
        }
    }
}

