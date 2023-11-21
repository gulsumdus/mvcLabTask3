using MVClab3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVClab3.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _context.EmployeeTable.ToListAsync();
            return View(employees);
        }

        // GET: Kullanicis/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeTable == null)
            {
                return NotFound();
            }

            var employee = await _context.EmployeeTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,BirthDate,Position,Image")] Employee employee)
        {
            // if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // return View(employee);
        }

        // GET: Employees/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeTable == null)
            {
                return NotFound();
            }

            var employee = await _context.EmployeeTable.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,BirthDate,Position,Image")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            // return View(employee);
        }

        // GET: Employees/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.EmployeeTable.FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Kullanicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeTable == null)
            {
                return Problem("Entity set 'YemekContext.KullaniciTable'  is null.");
            }
            var employee = await _context.EmployeeTable.FindAsync(id);
            if (employee != null)
            {
                _context.EmployeeTable.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return (_context.EmployeeTable?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}