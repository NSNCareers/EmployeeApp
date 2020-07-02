using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dot.NetCoreWebApp.Models;
using Microsoft.Extensions.Logging;

namespace Dot.NetCoreWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(EmployeeContext context, ILogger<EmployeeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _context.Employees.ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }
        }

       

        // GET: Employee/Create
        public IActionResult AddOrEdit(int id=0)
        {
            try
            {
                if (id == 0)
                {
                    return View(new Employee());
                }
                else
                {
                    return View(_context.Employees.Find(id));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("EmployeeId,FullName,EmpCode,Position,OfficeLocation")] Employee employee)
      {
            if (ModelState.IsValid)
            {

                try
                {
                    if (employee.EmployeeId == 0)
                    {
                        _context.Add(employee);
                    }
                    else
                    {
                        _context.Update(employee);
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return View();
                }
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var emp = await _context.Employees.FindAsync(id);
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }
        }
    }
}
