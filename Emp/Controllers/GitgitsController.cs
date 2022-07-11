using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Emp.Data;
using Emp.Models;

namespace Emp.Controllers
{
    public class GitgitsController : Controller
    {
        private readonly EmpContext _context;

        public GitgitsController(EmpContext context)
        {
            _context = context;
        }

        // GET: Gitgits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gitgit.ToListAsync());
        }

        // GET: Gitgits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gitgit = await _context.Gitgit
                .FirstOrDefaultAsync(m => m.EId == id);
            if (gitgit == null)
            {
                return NotFound();
            }

            return View(gitgit);
        }

        // GET: Gitgits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gitgits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EId,EName,EmployeeId,EDesign,EDoj")] Gitgit gitgit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gitgit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gitgit);
        }

        // GET: Gitgits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gitgit = await _context.Gitgit.FindAsync(id);
            if (gitgit == null)
            {
                return NotFound();
            }
            return View(gitgit);
        }

        // POST: Gitgits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EId,EName,EmployeeId,EDesign,EDoj")] Gitgit gitgit)
        {
            if (id != gitgit.EId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gitgit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GitgitExists(gitgit.EId))
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
            return View(gitgit);
        }

        // GET: Gitgits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gitgit = await _context.Gitgit
                .FirstOrDefaultAsync(m => m.EId == id);
            if (gitgit == null)
            {
                return NotFound();
            }

            return View(gitgit);
        }

        // POST: Gitgits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gitgit = await _context.Gitgit.FindAsync(id);
            _context.Gitgit.Remove(gitgit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GitgitExists(int id)
        {
            return _context.Gitgit.Any(e => e.EId == id);
        }
    }
}
