using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UIdea.Data;
using UIdea.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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

        // GET: Ideas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Idea.ToListAsync());
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
}
