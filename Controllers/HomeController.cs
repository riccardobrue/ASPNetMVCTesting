using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetMVCTesting.Models;
using ASPNetMVCTesting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNetMVCTesting.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (Database db = new Database())
            {
                List<Course> coursesList = await db.Courses
                .Include(course => course.Exams)
                .ToListAsync();
                return View(coursesList);
            }

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
