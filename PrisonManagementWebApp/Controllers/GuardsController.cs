using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrisonManagementWebApp.Data;
using PrisonManagementWebApp.Models;

namespace PrisonManagementWebApp.Controllers
{
    public class GuardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Guards
        public async Task<IActionResult> Index()
        {
              return View(await _context.Guards.ToListAsync());
        }

        // GET: Guards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Guards == null)
            {
                return NotFound();
            }

            var guard = await _context.Guards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guard == null)
            {
                return NotFound();
            }

            return View(guard);
        }

        // GET: Guards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Image,Genger,Id,CreationDateTime,UpdatedDateTime")] Guard guard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guard);
        }

        // GET: Guards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Guards == null)
            {
                return NotFound();
            }

            var guard = await _context.Guards.FindAsync(id);
            if (guard == null)
            {
                return NotFound();
            }
            return View(guard);
        }

        // POST: Guards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Image,Genger,Id,CreationDateTime,UpdatedDateTime")] Guard guard)
        {
            if (id != guard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuardExists(guard.Id))
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
            return View(guard);
        }

        // GET: Guards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Guards == null)
            {
                return NotFound();
            }

            var guard = await _context.Guards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guard == null)
            {
                return NotFound();
            }

            return View(guard);
        }

        // POST: Guards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Guards == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Guards'  is null.");
            }
            var guard = await _context.Guards.FindAsync(id);
            if (guard != null)
            {
                _context.Guards.Remove(guard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuardExists(int id)
        {
          return _context.Guards.Any(e => e.Id == id);
        }
    }
}
