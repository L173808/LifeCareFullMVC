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
    public class DoctorModulesController : Controller
    {
        private readonly LifeCareFullMVCContext _context;

        public DoctorModulesController(LifeCareFullMVCContext context)
        {
            _context = context;
        }

        // GET: DoctorModules
        public async Task<IActionResult> Index()
        {
            return View(await _context.DoctorModule.ToListAsync());
        }

        // GET: DoctorModules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorModule = await _context.DoctorModule
                .FirstOrDefaultAsync(m => m.id == id);
            if (doctorModule == null)
            {
                return NotFound();
            }

            return View(doctorModule);
        }

        // GET: DoctorModules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorModules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Contact,Email,Speciality")] DoctorModule doctorModule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorModule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorModule);
        }

        // GET: DoctorModules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorModule = await _context.DoctorModule.FindAsync(id);
            if (doctorModule == null)
            {
                return NotFound();
            }
            return View(doctorModule);
        }

        // POST: DoctorModules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Contact,Email,Speciality")] DoctorModule doctorModule)
        {
            if (id != doctorModule.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorModule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorModuleExists(doctorModule.id))
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
            return View(doctorModule);
        }

        // GET: DoctorModules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorModule = await _context.DoctorModule
                .FirstOrDefaultAsync(m => m.id == id);
            if (doctorModule == null)
            {
                return NotFound();
            }

            return View(doctorModule);
        }

        // POST: DoctorModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorModule = await _context.DoctorModule.FindAsync(id);
            _context.DoctorModule.Remove(doctorModule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorModuleExists(int id)
        {
            return _context.DoctorModule.Any(e => e.id == id);
        }
    }
}
