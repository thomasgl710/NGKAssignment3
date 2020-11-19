using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NGKAssignment3.Data;
using NGKAssignment3.Models;

namespace NGKAssignment3.Controllers
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

            var weatherStation = await _context.WeatherStations
                .FirstOrDefaultAsync(m => m.WeatherStationId == id);
            if (weatherStation == null)
            {
                return NotFound();
            }

            return View(weatherStation);
        }

        // GET: WeatherStations/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult SelectDate()
        {
            return View();
        }
        public async Task<IActionResult> ThreeLatestWeatherData()
        {
            return View(await _context.WeatherStations.ToListAsync());
        }
        public async Task<IActionResult> List()
        {
            return View(await _context.WeatherStations.ToListAsync());
        }
        // POST: WeatherStations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WeatherStationId,Name,Lat,Lon,Time,Temperatur,Humidity,AirPressure")] WeatherStation weatherStation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weatherStation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weatherStation);
        }

        // GET: WeatherStations/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherStation = await _context.WeatherStations.FindAsync(id);
            if (weatherStation == null)
            {
                return NotFound();
            }
            return View(weatherStation);
        }

        // POST: WeatherStations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("WeatherStationId,Name,Lat,Lon,Time,Temperatur,Humidity,AirPressure")] WeatherStation weatherStation)
        {
            if (id != weatherStation.WeatherStationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weatherStation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherStationExists(weatherStation.WeatherStationId))
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
            return View(weatherStation);
        }

        // GET: WeatherStations/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherStation = await _context.WeatherStations
                .FirstOrDefaultAsync(m => m.WeatherStationId == id);
            if (weatherStation == null)
            {
                return NotFound();
            }

            return View(weatherStation);
        }

        // POST: WeatherStations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var weatherStation = await _context.WeatherStations.FindAsync(id);
            _context.WeatherStations.Remove(weatherStation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherStationExists(long id)
        {
            return _context.WeatherStations.Any(e => e.WeatherStationId == id);
        }
    }
}
