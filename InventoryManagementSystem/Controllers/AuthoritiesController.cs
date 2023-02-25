using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class AuthoritiesController : Controller
    {
        private readonly InventoryManagementSystemContext _context;

        public AuthoritiesController(InventoryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: Authorities
        public async Task<IActionResult> Index()
        {
              return View(await _context.Authority.ToListAsync());
        }

        // GET: Authorities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Authority == null)
            {
                return NotFound();
            }

            var authority = await _context.Authority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authority == null)
            {
                return NotFound();
            }

            return View(authority);
        }

        // GET: Authorities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authorities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Authority authority)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authority);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authority);
        }

        // GET: Authorities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Authority == null)
            {
                return NotFound();
            }

            var authority = await _context.Authority.FindAsync(id);
            if (authority == null)
            {
                return NotFound();
            }
            return View(authority);
        }

        // POST: Authorities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Authority authority)
        {
            if (id != authority.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authority);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorityExists(authority.Id))
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
            return View(authority);
        }

        // GET: Authorities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Authority == null)
            {
                return NotFound();
            }

            var authority = await _context.Authority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authority == null)
            {
                return NotFound();
            }

            return View(authority);
        }

        // POST: Authorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Authority == null)
            {
                return Problem("Entity set 'InventoryManagementSystemContext.Authority'  is null.");
            }
            var authority = await _context.Authority.FindAsync(id);
            if (authority != null)
            {
                _context.Authority.Remove(authority);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorityExists(int id)
        {
          return _context.Authority.Any(e => e.Id == id);
        }
    }
}
