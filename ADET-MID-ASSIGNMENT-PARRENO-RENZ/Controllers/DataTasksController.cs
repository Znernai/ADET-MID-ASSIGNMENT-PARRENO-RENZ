using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment.Data;
using Assignment.Models;

namespace Assignment.Controllers
{
    public class DataTasksController : Controller
    {
        private readonly DataTaskContext _context;

        public DataTasksController(DataTaskContext context)
        {
            _context = context;
        }

        // GET: DataTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Todo.ToListAsync());
        }

        // GET: DataTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataTask = await _context.Todo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dataTask == null)
            {
                return NotFound();
            }

            return View(dataTask);
        }

        // GET: DataTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,What_Date,Start_Date,Finish_Date,Total_Of_Hours")] DataTask dataTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataTask);
        }

        // GET: DataTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataTask = await _context.Todo.FindAsync(id);
            if (dataTask == null)
            {
                return NotFound();
            }
            return View(dataTask);
        }

        // POST: DataTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,What_Date,Start_Date,Finish_Date,Total_Of_Hours")] DataTask dataTask)
        {
            if (id != dataTask.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataTaskExists(dataTask.ID))
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
            return View(dataTask);
        }

        // GET: DataTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataTask = await _context.Todo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dataTask == null)
            {
                return NotFound();
            }

            return View(dataTask);
        }

        // POST: DataTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataTask = await _context.Todo.FindAsync(id);
            _context.Todo.Remove(dataTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataTaskExists(int id)
        {
            return _context.Todo.Any(e => e.ID == id);
        }
    }
}
