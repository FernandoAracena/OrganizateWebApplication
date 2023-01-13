using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganizateWebApplication.Data;
using OrganizateWebApplication.Models;

namespace OrganizateWebApplication.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assignments
        public async Task<IActionResult> Index()
        {
              return View(await _context.Assignment.ToListAsync());
        }

        // GET: Assignments/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View(await _context.Assignment.ToListAsync());
        }

        // GET: Assignments/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return View("Index", await _context.Assignment.Where(a => a.AssignmentName.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Assignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assignment == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignment
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET: Assignments/Create

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignmentId,AssignmentName,AssignmentDescription")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        [Authorize]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assignment == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignment.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignmentId,AssignmentName,AssignmentDescription")] Assignment assignment)
        {
            if (id != assignment.AssignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.AssignmentId))
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
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assignment == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignment
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assignment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Assignment'  is null.");
            }
            var assignment = await _context.Assignment.FindAsync(id);
            if (assignment != null)
            {
                _context.Assignment.Remove(assignment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
          return _context.Assignment.Any(e => e.AssignmentId == id);
        }
    }
}
