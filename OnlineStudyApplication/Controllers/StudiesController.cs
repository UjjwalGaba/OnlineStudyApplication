using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
// add reference to package to use Authorization
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineStudyApplication.Data;
using OnlineStudyApplication.Models;

namespace OnlineStudyApplication.Controllers
{
    // protect this controller
    [Authorize(Roles = "Administrator")] 
    
    public class StudiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Studies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Studies.Include(s => s.Course).OrderBy(s => s.ChapterName);
            return View("Index", await applicationDbContext.ToListAsync());
        }

        // GET: Studies/Details/5
        // This attribute will allow anybody to access this section

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var study = await _context.Studies
                .Include(s => s.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (study == null)
            {
                return NotFound();
            }

            return View("Details", study);
        }

        // GET: Studies/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses.OrderBy(c => c.CourseName), "Id", "CourseName");
            return View("Create");
        }

       

        // POST: Studies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ChapterName,ChapterDescription,CourseId")] Study study, IFormFile FileUpload)
        {
            if (ModelState.IsValid)
            {

                // upload photo and attach to the new product if any
                if (FileUpload != null)
                {
                    var filePath = Path.GetTempFileName(); // get image from cache
                    var fileName = Guid.NewGuid() + "-" + FileUpload.FileName; // add unique id as prefix to file name
                    var uploadPath = System.IO.Directory.GetCurrentDirectory() + "\\wwwroot\\img\\file\\" + fileName;

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await FileUpload.CopyToAsync(stream);
                    }

                    // add unique Image file name to the new product object before saving
                    study.FileUpload = fileName;
                }


                _context.Add(study);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseName", study.CourseId);
            return View("Create",study);
        }

       

        // GET: Studies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var study = await _context.Studies.FindAsync(id);
            if (study == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseName", study.CourseId);
            return View(study);
        }

        // POST: Studies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ChapterName,ChapterDescription,FileUpload,CourseId")] Study study)
        {
            if (id != study.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(study);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyExists(study.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseName", study.CourseId);
            return View(study);
        }

        // GET: Studies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var study = await _context.Studies
                .Include(s => s.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (study == null)
            {
                return NotFound();
            }

            return View("Delete", await _context.Studies.ToListAsync());
        }

        // POST: Studies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var study = await _context.Studies.FindAsync(id);
            _context.Studies.Remove(study);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudyExists(int id)
        {
            return _context.Studies.Any(e => e.Id == id);
        }


        


    }

    
}
