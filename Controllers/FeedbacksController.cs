using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DaVinci.Models;
using DaVinci.Persistencia;

namespace DaVinci.Controllers
{
    public class FeedbacksController : Controller
    {
        private readonly OracleFIAPDbContext _context;

        public FeedbacksController(OracleFIAPDbContext context)
        {
            _context = context;
        }

        // GET: Feedbacks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Feedbacks.ToListAsync());
        }

        // GET: Feedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbacks = await _context.Feedbacks
                .FirstOrDefaultAsync(m => m.IdFeedback == id);
            if (feedbacks == null)
            {
                return NotFound();
            }

            return View(feedbacks);
        }

        // GET: Feedbacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFeedback,Comentario,DataFeedback,Avaliacao,IdCliente,IdProduto")] Feedbacks feedbacks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedbacks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feedbacks);
        }

        // GET: Feedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbacks = await _context.Feedbacks.FindAsync(id);
            if (feedbacks == null)
            {
                return NotFound();
            }
            return View(feedbacks);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFeedback,Comentario,DataFeedback,Avaliacao,IdCliente,IdProduto")] Feedbacks feedbacks)
        {
            if (id != feedbacks.IdFeedback)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedbacks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbacksExists(feedbacks.IdFeedback))
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
            return View(feedbacks);
        }

        // GET: Feedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbacks = await _context.Feedbacks
                .FirstOrDefaultAsync(m => m.IdFeedback == id);
            if (feedbacks == null)
            {
                return NotFound();
            }

            return View(feedbacks);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedbacks = await _context.Feedbacks.FindAsync(id);
            if (feedbacks != null)
            {
                _context.Feedbacks.Remove(feedbacks);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbacksExists(int id)
        {
            return _context.Feedbacks.Any(e => e.IdFeedback == id);
        }
    }
}
