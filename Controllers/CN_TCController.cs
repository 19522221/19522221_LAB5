using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAB5.Data;
using LAB5.Models;

namespace LAB5.Controllers
{
    public class CN_TCController : Controller
    {
        private readonly AppDbContext _context;

        public CN_TCController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CN_TC
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.CN_TC.Include(c => c.CongNhan).Include(c => c.TrieuChung);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Select()
        {
            var appDbContext = _context.CN_TC.Include(c => c.CongNhan).Include(c => c.TrieuChung);
            return View(await appDbContext.ToListAsync());
        }

        // GET: CN_TC/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cN_TC = await _context.CN_TC
                .Include(c => c.CongNhan)
                .Include(c => c.TrieuChung)
                .FirstOrDefaultAsync(m => m.MaCongNhan == id);
            if (cN_TC == null)
            {
                return NotFound();
            }

            return View(cN_TC);
        }

        // GET: CN_TC/Create
        public IActionResult Create()
        {
            ViewData["MaCongNhan"] = new SelectList(_context.Set<CongNhan>(), "MaCongNhan", "MaCongNhan");
            ViewData["MaTrieuChung"] = new SelectList(_context.TrieuChung, "MaTrieuChung", "MaTrieuChung");
            return View();
        }

        // POST: CN_TC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCongNhan,MaTrieuChung")] CN_TC cN_TC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cN_TC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaCongNhan"] = new SelectList(_context.Set<CongNhan>(), "MaCongNhan", "MaCongNhan", cN_TC.MaCongNhan);
            ViewData["MaTrieuChung"] = new SelectList(_context.TrieuChung, "MaTrieuChung", "MaTrieuChung", cN_TC.MaTrieuChung);
            return View(cN_TC);
        }

        // GET: CN_TC/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cN_TC = await _context.CN_TC.FindAsync(id);
            if (cN_TC == null)
            {
                return NotFound();
            }
            ViewData["MaCongNhan"] = new SelectList(_context.Set<CongNhan>(), "MaCongNhan", "MaCongNhan", cN_TC.MaCongNhan);
            ViewData["MaTrieuChung"] = new SelectList(_context.TrieuChung, "MaTrieuChung", "MaTrieuChung", cN_TC.MaTrieuChung);
            return View(cN_TC);
        }

        // POST: CN_TC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaCongNhan,MaTrieuChung")] CN_TC cN_TC)
        {
            if (id != cN_TC.MaCongNhan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cN_TC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CN_TCExists(cN_TC.MaCongNhan))
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
            ViewData["MaCongNhan"] = new SelectList(_context.Set<CongNhan>(), "MaCongNhan", "MaCongNhan", cN_TC.MaCongNhan);
            ViewData["MaTrieuChung"] = new SelectList(_context.TrieuChung, "MaTrieuChung", "MaTrieuChung", cN_TC.MaTrieuChung);
            return View(cN_TC);
        }

        // GET: CN_TC/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cN_TC = await _context.CN_TC
                .Include(c => c.CongNhan)
                .Include(c => c.TrieuChung)
                .FirstOrDefaultAsync(m => m.MaCongNhan == id);
            if (cN_TC == null)
            {
                return NotFound();
            }

            return View(cN_TC);
        }

        // POST: CN_TC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cN_TC = await _context.CN_TC.FindAsync(id);
            _context.CN_TC.Remove(cN_TC);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CN_TCExists(string id)
        {
            return _context.CN_TC.Any(e => e.MaCongNhan == id);
        }
    }
}
