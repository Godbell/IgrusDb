using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IGRUSDB_ASP.Data;
using IGRUSDB_ASP.Models;

namespace IGRUSDB_ASP.Controllers
{
    public class CMembersController : Controller
    {
        private readonly IgrusDbContext _context;

        public CMembersController(IgrusDbContext context)
        {
            _context = context;
        }

        // GET: CMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.CMembers.ToListAsync());
        }

        // GET: CMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cMember = await _context.CMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cMember == null)
            {
                return NotFound();
            }

            return View(cMember);
        }

        // GET: CMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Major,PhoneNumber,Email,Grade,Comment")] CMember cMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cMember);
        }

        // GET: CMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cMember = await _context.CMembers.FindAsync(id);
            if (cMember == null)
            {
                return NotFound();
            }
            return View(cMember);
        }

        // POST: CMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Major,PhoneNumber,Email,Grade,Comment")] CMember cMember)
        {
            if (id != cMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CMemberExists(cMember.Id))
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
            return View(cMember);
        }

        // GET: CMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cMember = await _context.CMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cMember == null)
            {
                return NotFound();
            }

            return View(cMember);
        }

        // POST: CMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cMember = await _context.CMembers.FindAsync(id);
            _context.CMembers.Remove(cMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CMemberExists(int id)
        {
            return _context.CMembers.Any(e => e.Id == id);
        }
    }
}
