using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineStudyApplication.Data;
using OnlineStudyApplication.Models;

namespace OnlineStudyApplication.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchoolController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: School
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.OrderBy(s => s.CourseName).ToListAsync());
        }

        // GET: /Store/Browse/<id>
        public IActionResult Browse(int id)
        {
            // Use context object to query the database and get a list of products by categoryId
            // Use LINQ
            // vs SQL >>> string query = "SELECT * FROM STUDIES WHERE COURSEID = @COURID";

            var studies = _context.Studies
                          .Where(s => s.CourseId == id)
                          .OrderBy(s => s.ChapterName)
                          .ToList();

            // how else can i send data back to the view?
            // ViewBag.course = _context.Courses.Where(c => c.Id == id).FirstOrDefault().CourseName; 
            ViewBag.course = _context.Courses.Find(id).CourseName;

            // pass the list to be used as a model to the view
            return View(studies);
        }

        
    }
}
