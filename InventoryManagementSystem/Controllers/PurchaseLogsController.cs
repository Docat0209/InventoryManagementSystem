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
    public class PurchaseLogsController : Controller
    {
        private readonly InventoryManagementSystemContext _context;

        public PurchaseLogsController(InventoryManagementSystemContext context)
        {
            _context = context;
        }

        // GET: PurchaseLogs
        public async Task<IActionResult> Index()
        {
            var inventoryManagementSystemContext = _context.PurchaseLog.Include(p => p.Item).Include(p => p.Supplier);
            return View(await inventoryManagementSystemContext.ToListAsync());
        }

        // GET: PurchaseLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PurchaseLog == null)
            {
                return NotFound();
            }

            var purchaseLog = await _context.PurchaseLog
                .Include(p => p.Item)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseLog == null)
            {
                return NotFound();
            }

            return View(purchaseLog);
        }

        // GET: PurchaseLogs/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Name");
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Name");
            return View();
        }

        // POST: PurchaseLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SupplierId,ItemId,Price,PurchaseDate,ExpirationDate,Description")] PurchaseLog purchaseLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Name", purchaseLog.ItemId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Name", purchaseLog.SupplierId);
            return View(purchaseLog);
        }

        // GET: PurchaseLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PurchaseLog == null)
            {
                return NotFound();
            }

            var purchaseLog = await _context.PurchaseLog.FindAsync(id);
            if (purchaseLog == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Name", purchaseLog.ItemId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Name", purchaseLog.SupplierId);
            return View(purchaseLog);
        }

        // POST: PurchaseLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SupplierId,ItemId,Price,PurchaseDate,ExpirationDate,Description")] PurchaseLog purchaseLog)
        {
            if (id != purchaseLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseLogExists(purchaseLog.Id))
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
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Name", purchaseLog.ItemId);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "Id", "Name", purchaseLog.SupplierId);
            return View(purchaseLog);
        }

        // GET: PurchaseLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PurchaseLog == null)
            {
                return NotFound();
            }

            var purchaseLog = await _context.PurchaseLog
                .Include(p => p.Item)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseLog == null)
            {
                return NotFound();
            }

            return View(purchaseLog);
        }

        // POST: PurchaseLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PurchaseLog == null)
            {
                return Problem("Entity set 'InventoryManagementSystemContext.PurchaseLog'  is null.");
            }
            var purchaseLog = await _context.PurchaseLog.FindAsync(id);
            if (purchaseLog != null)
            {
                _context.PurchaseLog.Remove(purchaseLog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseLogExists(int id)
        {
          return _context.PurchaseLog.Any(e => e.Id == id);
        }
    }
}
