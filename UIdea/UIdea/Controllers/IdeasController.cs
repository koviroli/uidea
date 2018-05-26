using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UIdea.Models;



namespace UIdea.Controllers
{
    public class IdeasController : Controller
    {
        private readonly UIdeaContext _context;
        private readonly IHostingEnvironment _env;

        public IdeasController(UIdeaContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
            
        }

        public IActionResult Ideas()
        {
            return View();
        }
        
        public async Task<IActionResult> Index(string searchString, int? page)
        {
            var ideas = from i in _context.Idea
                         select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                ideas = ideas.Where(s => s.RequiredMembers.Contains(searchString));
            }

            int pageSize = 10;
            return View(await PaginatedList<Idea>.CreateAsync(ideas.AsNoTracking(), page ?? 1, pageSize));
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
        public async Task<IActionResult> Create([Bind("ID,OwnerID,Title,Description,Members,RequiredMembers," +
            "FacebookContact,InstagramContact,TwitterContact,GitHubContact,EmailContact,LinkedinContact,OtherContact,AvatarImage")] Idea idea, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var actualUserId = User.GetUserId();
                idea.OwnerID = actualUserId;
                idea.AvatarImage = new byte[0];
                if(file != null && file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        idea.AvatarImage = memoryStream.ToArray();
                    }
                }
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
        public async Task<IActionResult> Edit(string id, [Bind("ID,OwnerID,Title,Description,Members,RequiredMembers," +
            "FacebookContact,InstagramContact,TwitterContact,GitHubContact,EmailContact,LinkedinContact,OtherContact,AvatarImage")] Idea idea)
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
                return RedirectToAction("Details", new { id = idea.ID });
            }
            return View(idea);
        }

        // POST: Ideas/Delete/5
        [HttpPost, ActionName("FileUpload")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FileUpload(string ID, IFormFile file)
        {
            var actualIdea = await _context.Idea.SingleOrDefaultAsync(i => i.ID.Equals(ID));
            
            if(file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    actualIdea.AvatarImage = memoryStream.ToArray();
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actualIdea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdeaExists(actualIdea.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToAction("Edit", new { id = actualIdea.ID });
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
