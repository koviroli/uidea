using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UIdea.Data;
using UIdea.Models;

namespace UIdea.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UIdeaContext _uideaContext;

        public HomeController(ApplicationDbContext appdbcontext, UIdeaContext uideacontext)
        {
            _appDbContext = appdbcontext;
            _uideaContext = uideacontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Users(string searchString, int? page)
        {
            ViewData["Message"] = "Your application description page.";

            var users = from u in _appDbContext.Users
                        select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.UserName.Equals(searchString));
            }

            int pageSize = 16;
            return View(await PaginatedList<ApplicationUser>.CreateAsync(users.AsNoTracking(), page ?? 1, pageSize));
        }

        public async Task<IActionResult> UserProfile(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _appDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult Tags()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
