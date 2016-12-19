using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrototypeAdal5.Data;
using PrototypeAdal5.Models;
using PrototypeAdal5.Models.ReleaseViewModels;
using Newtonsoft.Json;
using System.Text;
using PrototypeAdal5;

namespace PrototypeAdal5.Controllers
{
    public class ReleasesController : Controller
    {
        private readonly ReleaseContext _context;

        public ReleasesController(ReleaseContext context)
        {
            _context = context;
        }

        // GET: Releases
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            var releases = from r in _context.Releases
                           select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                releases =
                    releases.Where(r => r.ProductName.Contains(searchString));
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            switch (sortOrder)
            {
                case "name_desc":
                    releases = releases.OrderByDescending(r => r.ProductName);
                    break;
                case "date_desc":
                    releases = releases.OrderBy(r => r.SubmissionDate);
                    break;
                default:
                    releases = releases.OrderBy(r => r.ProductName);
                    break;
            }

            int pageSize = 6;
            return View(await PaginatedList<Release>.CreateAsync(releases.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Releases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var release = await _context.Releases
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (release == null)
            {
                return NotFound();
            }

            return View(release);
        }

        // GET: Releases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Releases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ID,ApprovalStatus,ApprovedBy,ApprovedDate,ProductName,ReleaseNotes,SubmissionDate,VersionNumber")] Release release)
        {
            if (ModelState.IsValid)
            {
                _context.Add(release);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(release);
        }

        // GET: Releases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var release = await _context.Releases.SingleOrDefaultAsync(m => m.ID == id);
            if (release == null)
            {
                return NotFound();
            }
            return View(release);
        }

        // POST: Releases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var releaseToUpdate = await _context.Releases.SingleOrDefaultAsync(r => r.ID == id);

            if (
                await
                    TryUpdateModelAsync<Release>(releaseToUpdate, "", r => r.ProductName, r => r.VersionNumber,
                        r => r.ReleaseNotes, r => r.SubmissionDate, r => r.ApprovalStatus, r => r.ApprovedBy,
                        r => r.ApprovedDate))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error
                    ModelState.AddModelError("", "Unable to save changes. " +
                                                 "Please try again later.");
                }
            }
            return View(releaseToUpdate);
        }

        // GET: Releases/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var release = await _context.Releases
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (release == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. Please try again";
            }

            return View(release);
        }

        // POST: Releases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var release = await _context.Releases
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (release == null)
            {
                return RedirectToAction("Index");
            }
            try
            {
                _context.Releases.Remove(release);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        }

        private bool ReleaseExists(int id)
        {
            return _context.Releases.Any(e => e.ID == id);
        }
    }
}
