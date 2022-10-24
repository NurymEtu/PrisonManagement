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
    public class CameraLivesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CameraLivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CameraLives
        public async Task<IActionResult> Index()
        {
              return View(await _context.CameraLives.ToListAsync());
        }

        // GET: CameraLives/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.CameraLives == null)
            {
                return NotFound();
            }

            var cameraLive = await _context.CameraLives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cameraLive == null)
            {
                return NotFound();
            }

            return View(cameraLive);
        }

        // GET: CameraLives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CameraLives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CamNumber,LiveUrl,Id,CreationDateTime,UpdatedDateTime")] CameraLive cameraLive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cameraLive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cameraLive);
        }

        // GET: CameraLives/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.CameraLives == null)
            {
                return NotFound();
            }

            var cameraLive = await _context.CameraLives.FindAsync(id);
            if (cameraLive == null)
            {
                return NotFound();
            }
            return View(cameraLive);
        }

        // POST: CameraLives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CamNumber,LiveUrl,Id,CreationDateTime,UpdatedDateTime")] CameraLive cameraLive)
        {
            if (id != cameraLive.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cameraLive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CameraLiveExists(cameraLive.Id))
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
            return View(cameraLive);
        }

        // GET: CameraLives/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.CameraLives == null)
            {
                return NotFound();
            }

            var cameraLive = await _context.CameraLives
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cameraLive == null)
            {
                return NotFound();
            }

            return View(cameraLive);
        }

        // POST: CameraLives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.CameraLives == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CameraLives'  is null.");
            }
            var cameraLive = await _context.CameraLives.FindAsync(id);
            if (cameraLive != null)
            {
                _context.CameraLives.Remove(cameraLive);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CameraLiveExists(Guid id)
        {
          return _context.CameraLives.Any(e => e.Id == id);
        }
    }
}
