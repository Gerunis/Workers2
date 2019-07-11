using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workers.Models;

namespace Workers.Controllers
{
    public class WorkersController : Controller
    {
        private readonly WorkersDb _workersDb;
        public WorkersController()
        {
            _context = context;
        }

        // GET: Workers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Workers
                .Include(x => x.Language)
                .Include(x => x.Department)
                .ToListAsync());
        }

        // GET: Workers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers
                .Where(x => x.Id == id)
                .Include(x => x.Language)
                .Include(x => x.Department).FirstOrDefaultAsync();
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // GET: Workers/Create
        public IActionResult Create()
        {
            AddTablesInViewBag();
            return View();
        }

        // POST: Workers/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Worker worker)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                worker.Department = await _context.Departments.FindAsync(worker.Department.Id);
                worker.Language = await _context.Languages.FindAsync(worker.Language.Id);
                _context.Add(worker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            AddTablesInViewBag();
            return View(worker);
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers
                .Where(x => x.Id == id)
                .Include(x => x.Language)
                .Include(x => x.Department).FirstOrDefaultAsync();
            if (worker == null)
            {
                return NotFound();
            }

            AddTablesInViewBag();
            return View(worker);
        }

        // POST: Workers/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Worker worker)
        {
            if (id != worker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                worker.Department = await _context.Departments.FindAsync(worker.Department.Id);
                worker.Language = await _context.Languages.FindAsync(worker.Language.Id);
                try
                {
                    _context.Update(worker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerExists(worker.Id))
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

            AddTablesInViewBag();
            return View(worker);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var worker = await _context.Workers.FindAsync(id);
            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerExists(int id)
        {
            return _context.Workers.Any(e => e.Id == id);
        }

        private void AddTablesInViewBag()
        {
            ViewBag.Languages = new SelectList(_context.Languages, "Id", "Name");
            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name");
        }
    }
}