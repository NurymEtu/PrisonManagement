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
    public class PrisonersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrisonersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prisoners
        public async Task<IActionResult> Index()
        {
              return View(await _context.Prisoners.ToListAsync());
        }

        // GET: Prisoners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prisoners == null)
            {
                return NotFound();
            }

            var prisoner = await _context.Prisoners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prisoner == null)
            {
                return NotFound();
            }

            return View(prisoner);
        }

        // GET: Prisoners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prisoners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Age,Genger,Birthday,Image,FingetPrint,ContactName,ContactRelation,ContactContact,TimeServeStarts,TimeServeEnds,CrimeCommitter,CrimeDetails,Id,CreationDateTime,UpdatedDateTime")] Prisoner prisoner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prisoner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prisoner);
        }

        // GET: Prisoners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prisoners == null)
            {
                return NotFound();
            }

            var prisoner = await _context.Prisoners.FindAsync(id);
            if (prisoner == null)
            {
                return NotFound();
            }
            return View(prisoner);
        }

        // POST: Prisoners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Age,Genger,Birthday,Image,FingetPrint,ContactName,ContactRelation,ContactContact,TimeServeStarts,TimeServeEnds,CrimeCommitter,CrimeDetails,Id,CreationDateTime,UpdatedDateTime")] Prisoner prisoner)
        {
            if (id != prisoner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prisoner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrisonerExists(prisoner.Id))
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
            return View(prisoner);
        }

        // GET: Prisoners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prisoners == null)
            {
                return NotFound();
            }

            var prisoner = await _context.Prisoners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prisoner == null)
            {
                return NotFound();
            }

            return View(prisoner);
        }

        // POST: Prisoners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prisoners == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Prisoners'  is null.");
            }
            var prisoner = await _context.Prisoners.FindAsync(id);
            if (prisoner != null)
            {
                _context.Prisoners.Remove(prisoner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrisonerExists(int id)
        {
          return _context.Prisoners.Any(e => e.Id == id);
        }
    }
}
