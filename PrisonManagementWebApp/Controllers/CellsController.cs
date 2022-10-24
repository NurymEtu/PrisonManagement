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
    public class CellsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CellsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cells
        public async Task<IActionResult> Index()
        {
            var list = await _context.Cells.Include(x => x.Prisoners).Include(x => x.Guards).Include(x => x.CameraLives).ToListAsync();
            return View(list);
        }

        // GET: Cells/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Cells == null)
            {
                return NotFound();
            }

            var cell = await _context.Cells.Include(x => x.CameraLives).Include(x => x.Prisoners).Include(x => x.Guards)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cell == null)
            {
                return NotFound();
            }

            return View(cell);
        }

        // GET: Cells/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CellNumber,Number,Capacity,Id,CreationDateTime,UpdatedDateTime")] Cell cell)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cell);
        }

        // GET: Cells/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Cells == null)
            {
                return NotFound();
            }

            var cell = await _context.Cells.FindAsync(id);
            if (cell == null)
            {
                return NotFound();
            }
            return View(cell);
        }

        // POST: Cells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CellNumber,Number,Capacity,Id,CreationDateTime,UpdatedDateTime")] Cell cell)
        {
            if (id != cell.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CellExists(cell.Id))
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
            return View(cell);
        }

        // GET: Cells/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Cells == null)
            {
                return NotFound();
            }

            var cell = await _context.Cells
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cell == null)
            {
                return NotFound();
            }

            return View(cell);
        }

        // POST: Cells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Cells == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cells'  is null.");
            }
            var cell = await _context.Cells.FindAsync(id);
            if (cell != null)
            {
                _context.Cells.Remove(cell);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CellExists(Guid id)
        {
            return _context.Cells.Any(e => e.Id == id);
        }
    }
}
