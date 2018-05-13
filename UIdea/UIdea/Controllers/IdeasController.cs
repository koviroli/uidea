using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UIdea.Models;
using Microsoft.AspNetCore.Http;

namespace UIdea.Controllers
{
    public class IdeasController : Controller
    {
        private readonly UIdeaContext _context;

        public IdeasController(UIdeaContext context)
        {
            _context = context;
        }

        public IActionResult Ideas()
        {
            return View();
        }
        
        public async Task<IActionResult> Index(string searchString)
        {
            var ideas = from i in _context.Idea
                         select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                ideas = ideas.Where(s => s.RequiredMembers.Contains(searchString));
            }

            return View(await ideas.ToListAsync());
        }

        // GET: Ideas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idea = await _context.Idea
                .SingleOrDefaultAsync(m => m.ID == id);
            if (idea == null)
            {
                return NotFound();
            }

            return View(idea);
        }

        // GET: Ideas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ideas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OwnerID,Title,Description,Members,RequiredMembers")] Idea idea)
        {
            if (ModelState.IsValid)
            {
                var actualUserId = User.GetUserId();
                idea.OwnerID = actualUserId;
                _context.Add(idea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(idea);
        }

        // GET: Ideas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idea = await _context.Idea.SingleOrDefaultAsync(m => m.ID == id);
            if (idea == null)
            {
                return NotFound();
            }
            return View(idea);
        }

        // POST: Ideas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,OwnerID,Title,Description,Members,RequiredMembers")] Idea idea)
        {
            if (id != idea.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(idea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdeaExists(idea.ID))
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
            return View(idea);
        }

        // GET: Ideas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idea = await _context.Idea
                .SingleOrDefaultAsync(m => m.ID == id);
            if (idea == null)
            {
                return NotFound();
            }

            return View(idea);
        }

        // POST: Ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var idea = await _context.Idea.SingleOrDefaultAsync(m => m.ID == id);
            _context.Idea.Remove(idea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdeaExists(string id)
        {
            return _context.Idea.Any(e => e.ID == id);
        }
    }

    public static class QueryParamsExtensions
    {
        public static QueryParameters GetQueryParameters(this HttpContext context)
        {
            var dictionary = context.Request.Query.ToDictionary(d => d.Key, d => d.Value.ToString());
            return new QueryParameters(dictionary);
        }
    }

    public class QueryParameters : Dictionary<string, string>
    {
        public QueryParameters() : base() { }
        public QueryParameters(int capacity) : base(capacity) { }
        public QueryParameters(IDictionary<string, string> dictionary) : base(dictionary) { }

        public QueryParameters WithRoute(string routeParam, string routeValue)
        {
            if(!ContainsKey(routeParam))
                Add(routeParam, routeValue);

            return this;
        }
    }
}
