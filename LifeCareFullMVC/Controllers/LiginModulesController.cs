using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LifeCareFullMVC.Data;
using LifeCareFullMVC.Models;

namespace LifeCareFullMVC.Controllers
{
    public class LiginModulesController : Controller
    {
        private readonly LifeCareFullMVCContext _context;

        public LiginModulesController(LifeCareFullMVCContext context)
        {
            _context = context;
        }

        // GET: LiginModules
        public async Task<IActionResult> Index()
        {
            return View(await _context.LiginModule.ToListAsync());
        }

        // GET: LiginModules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liginModule = await _context.LiginModule
                .FirstOrDefaultAsync(m => m.id == id);
            if (liginModule == null)
            {
                return NotFound();
            }

            return View(liginModule);
        }

        // GET: LiginModules/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult DashboardModule()
        {
            return View();
        }
        public IActionResult WrongModule()
        {
            return View();
        }


        // POST: LiginModules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Email,Password")] LiginModule liginModule)
        {
            if (liginModule.Email.Equals("doctor@gmail.com") && liginModule.Password.Equals("12345"))
            {
                return RedirectToAction(nameof(DashboardModule));
            }
            else {
                return RedirectToAction(nameof(WrongModule));
            }
            
        }

        // GET: LiginModules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liginModule = await _context.LiginModule.FindAsync(id);
            if (liginModule == null)
            {
                return NotFound();
            }
            return View(liginModule);
        }

        // POST: LiginModules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Email,Password")] LiginModule liginModule)
        {
            if (id != liginModule.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(liginModule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LiginModuleExists(liginModule.id))
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
            return View(liginModule);
        }

        // GET: LiginModules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liginModule = await _context.LiginModule
                .FirstOrDefaultAsync(m => m.id == id);
            if (liginModule == null)
            {
                return NotFound();
            }

            return View(liginModule);
        }

        // POST: LiginModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var liginModule = await _context.LiginModule.FindAsync(id);
            _context.LiginModule.Remove(liginModule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LiginModuleExists(int id)
        {
            return _context.LiginModule.Any(e => e.id == id);
        }
    }
}
