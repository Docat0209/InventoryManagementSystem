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
    public class SellLogsController : Controller
    {
        private readonly InventoryManagementSystemContext _context;

        public SellLogsController(InventoryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: SellLogs
        public async Task<IActionResult> Index()
        {
            var inventoryManagementSystemContext = _context.SellLog.Include(s => s.Inventory).Include(s => s.User);
            return View(await inventoryManagementSystemContext.ToListAsync());
        }

        // GET: SellLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SellLog == null)
            {
                return NotFound();
            }

            var sellLog = await _context.SellLog
                .Include(s => s.Inventory)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellLog == null)
            {
                return NotFound();
            }

            return View(sellLog);
        }

        // GET: SellLogs/Create
        public IActionResult Create()
        {
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Account");
            return View();
        }

        // POST: SellLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,InventoryId,Price,SellDate")] SellLog sellLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "Id", "Id", sellLog.InventoryId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Account", sellLog.UserId);
            return View(sellLog);
        }

        // GET: SellLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SellLog == null)
            {
                return NotFound();
            }

            var sellLog = await _context.SellLog.FindAsync(id);
            if (sellLog == null)
            {
                return NotFound();
            }
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "Id", "Id", sellLog.InventoryId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Account", sellLog.UserId);
            return View(sellLog);
        }

        // POST: SellLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,InventoryId,Price,SellDate")] SellLog sellLog)
        {
            if (id != sellLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellLogExists(sellLog.Id))
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
            ViewData["InventoryId"] = new SelectList(_context.Inventory, "Id", "Id", sellLog.InventoryId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Account", sellLog.UserId);
            return View(sellLog);
        }

        // GET: SellLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SellLog == null)
            {
                return NotFound();
            }

            var sellLog = await _context.SellLog
                .Include(s => s.Inventory)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellLog == null)
            {
                return NotFound();
            }

            return View(sellLog);
        }

        // POST: SellLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SellLog == null)
            {
                return Problem("Entity set 'InventoryManagementSystemContext.SellLog'  is null.");
            }
            var sellLog = await _context.SellLog.FindAsync(id);
            if (sellLog != null)
            {
                _context.SellLog.Remove(sellLog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellLogExists(int id)
        {
          return _context.SellLog.Any(e => e.Id == id);
        }
    }
}
