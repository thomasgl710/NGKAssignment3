using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NGKAssignment3WithAuth.Data;
using NGKAssignment3WithAuth.Models;

namespace NGKAssignment3WithAuth.Controllers
{
    public class WeatherStationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeatherStationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WeatherStations
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeatherStations.ToListAsync());
        }

        // GET: WeatherStations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherStations = await _context.WeatherStations
                .FirstOrDefaultAsync(m => m.WeatherStationsId == id);
            if (weatherStations == null)
            {
                return NotFound();
            }

            return View(weatherStations);
        }

        // GET: WeatherStations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeatherStations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WeatherStationsId,Name,Lat,Lon,Time,Temperatur,Humidity,AirPressure")] WeatherStations weatherStations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weatherStations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weatherStations);
        }

        // GET: WeatherStations/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherStations = await _context.WeatherStations.FindAsync(id);
            if (weatherStations == null)
            {
                return NotFound();
            }
            return View(weatherStations);
        }

        // POST: WeatherStations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("WeatherStationsId,Name,Lat,Lon,Time,Temperatur,Humidity,AirPressure")] WeatherStations weatherStations)
        {
            if (id != weatherStations.WeatherStationsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weatherStations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherStationsExists(weatherStations.WeatherStationsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(weatherStations);
        }

        // GET: WeatherStations/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherStations = await _context.WeatherStations
                .FirstOrDefaultAsync(m => m.WeatherStationsId == id);
            if (weatherStations == null)
            {
                return NotFound();
            }

            return View(weatherStations);
        }

        // POST: WeatherStations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var weatherStations = await _context.WeatherStations.FindAsync(id);
            _context.WeatherStations.Remove(weatherStations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherStationsExists(long id)
        {
            return _context.WeatherStations.Any(e => e.WeatherStationsId == id);
        }
    }
}
