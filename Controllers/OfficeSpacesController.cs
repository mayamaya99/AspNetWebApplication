using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetWebApplication.Data;
using AspNetWebApplication.Models;

namespace AspNetWebApplication.Controllers
{
    public class OfficeSpacesController : Controller
    {
        private readonly AspNetWebApplicationDbContext _context;

        public OfficeSpacesController(AspNetWebApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OfficeSpaces
        public async Task<IActionResult> Index()
        {
            return View(await _context.OfficeSpace.ToListAsync());
        }
        // GET: OfficeSpaces/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View(await _context.OfficeSpace.ToListAsync());
        }

        // GET: OfficeSpaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeSpace = await _context.OfficeSpace
                .FirstOrDefaultAsync(m => m.Id == id);
            if (officeSpace == null)
            {
                return NotFound();
            }

            return View(officeSpace);
        }

        // GET: OfficeSpaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfficeSpaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PropertyType,PropertyPrice")] OfficeSpace officeSpace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(officeSpace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(officeSpace);
        }

        // GET: OfficeSpaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeSpace = await _context.OfficeSpace.FindAsync(id);
            if (officeSpace == null)
            {
                return NotFound();
            }
            return View(officeSpace);
        }

        // POST: OfficeSpaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PropertyType,PropertyPrice")] OfficeSpace officeSpace)
        {
            if (id != officeSpace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(officeSpace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficeSpaceExists(officeSpace.Id))
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
            return View(officeSpace);
        }

        // GET: OfficeSpaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeSpace = await _context.OfficeSpace
                .FirstOrDefaultAsync(m => m.Id == id);
            if (officeSpace == null)
            {
                return NotFound();
            }

            return View(officeSpace);
        }

        // POST: OfficeSpaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var officeSpace = await _context.OfficeSpace.FindAsync(id);
            _context.OfficeSpace.Remove(officeSpace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficeSpaceExists(int id)
        {
            return _context.OfficeSpace.Any(e => e.Id == id);
        }
    }
}
