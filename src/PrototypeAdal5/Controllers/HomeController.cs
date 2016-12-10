using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototypeAdal5.Data;
using PrototypeAdal5.Models.ReleaseViewModels;

namespace PrototypeAdal5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReleaseContext _context;

        public HomeController(ReleaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            IQueryable<SubmissionDateGroup> data =
                from release in _context.Releases
                group release by release.SubmissionDate
                into dateGroup
                select new SubmissionDateGroup()
                {
                    SubmissionDate = dateGroup.Key,
                    ReleaseCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
