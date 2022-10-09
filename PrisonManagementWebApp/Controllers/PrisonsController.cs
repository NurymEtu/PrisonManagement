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
    public class PrisonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrisonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prisons
        public async Task<IActionResult> Index()
        {
              return View(await _context.Prisons.ToListAsync());
        }

        // GET: Prisons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prisons == null)
            {
                return NotFound();
            }

            var prison = await _context.Prisons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prison == null)
            {
                return NotFound();
            }

            return View(prison);
        }

        // GET: Prisons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prisons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Number,Capacity,Id,CreationDateTime,UpdatedDateTime")] Prison prison)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prison);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prison);
        }

        // GET: Prisons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prisons == null)
            {
                return NotFound();
            }

            var prison = await _context.Prisons.FindAsync(id);
            if (prison == null)
            {
                return NotFound();
            }
            return View(prison);
        }

        // POST: Prisons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Number,Capacity,Id,CreationDateTime,UpdatedDateTime")] Prison prison)
        {
            if (id != prison.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prison);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrisonExists(prison.Id))
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
            return View(prison);
        }

        // GET: Prisons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prisons == null)
            {
                return NotFound();
            }

            var prison = await _context.Prisons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prison == null)
            {
                return NotFound();
            }

            return View(prison);
        }

        // POST: Prisons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prisons == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Prisons'  is null.");
            }
            var prison = await _context.Prisons.FindAsync(id);
            if (prison != null)
            {
                _context.Prisons.Remove(prison);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrisonExists(int id)
        {
          return _context.Prisons.Any(e => e.Id == id);
        }
    }
}
