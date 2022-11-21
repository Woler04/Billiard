using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Billiard.Models;

namespace Billiard.Controllers
{
    public class BilliardsController : Controller
    {
        private readonly BilliardDbContext _context;

        public BilliardsController(BilliardDbContext context)
        {
            _context = context;
        }

        // GET: Billiards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Billiards.ToListAsync());
        }

        // GET: Billiards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Billiards == null)
            {
                return NotFound();
            }

            var billiard = await _context.Billiards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billiard == null)
            {
                return NotFound();
            }

            return View(billiard);
        }

        // GET: Billiards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Billiards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Seats,IsForSmokers")] BilliardTables billiard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billiard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(billiard);
        }

        // GET: Billiards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Billiards == null)
            {
                return NotFound();
            }

            var billiard = await _context.Billiards.FindAsync(id);
            if (billiard == null)
            {
                return NotFound();
            }
            return View(billiard);
        }

        // POST: Billiards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Seats,IsForSmokers")] BilliardTables billiard)
        {
            if (id != billiard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billiard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BilliardExists(billiard.Id))
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
            return View(billiard);
        }

        // GET: Billiards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Billiards == null)
            {
                return NotFound();
            }

            var billiard = await _context.Billiards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billiard == null)
            {
                return NotFound();
            }

            return View(billiard);
        }

        // POST: Billiards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Billiards == null)
            {
                return Problem("Entity set 'BilliardDbContext.Billiards'  is null.");
            }
            var billiard = await _context.Billiards.FindAsync(id);
            if (billiard != null)
            {
                _context.Billiards.Remove(billiard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BilliardExists(int id)
        {
          return _context.Billiards.Any(e => e.Id == id);
        }
    }
}
