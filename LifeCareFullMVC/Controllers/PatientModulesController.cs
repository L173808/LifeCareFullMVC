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
    public class PatientModulesController : Controller
    {
        private readonly LifeCareFullMVCContext _context;

        public PatientModulesController(LifeCareFullMVCContext context)
        {
            _context = context;
        }

        // GET: PatientModules
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientModule.ToListAsync());
        }

        // GET: PatientModules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientModule = await _context.PatientModule
                .FirstOrDefaultAsync(m => m.id == id);
            if (patientModule == null)
            {
                return NotFound();
            }

            return View(patientModule);
        }

        // GET: PatientModules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientModules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Contact,Email,Disease")] PatientModule patientModule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientModule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientModule);
        }

        // GET: PatientModules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientModule = await _context.PatientModule.FindAsync(id);
            if (patientModule == null)
            {
                return NotFound();
            }
            return View(patientModule);
        }

        // POST: PatientModules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Contact,Email,Disease")] PatientModule patientModule)
        {
            if (id != patientModule.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientModule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientModuleExists(patientModule.id))
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
            return View(patientModule);
        }

        // GET: PatientModules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientModule = await _context.PatientModule
                .FirstOrDefaultAsync(m => m.id == id);
            if (patientModule == null)
            {
                return NotFound();
            }

            return View(patientModule);
        }

        // POST: PatientModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientModule = await _context.PatientModule.FindAsync(id);
            _context.PatientModule.Remove(patientModule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientModuleExists(int id)
        {
            return _context.PatientModule.Any(e => e.id == id);
        }
    }
}
