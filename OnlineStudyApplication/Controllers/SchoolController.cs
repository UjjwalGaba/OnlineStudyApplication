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

        
    }
}
