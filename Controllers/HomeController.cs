using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetMVCTesting.Models;
using ASPNetMVCTesting.Models.Requests;
using ASPNetMVCTesting.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNetMVCTesting.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICoursesService coursesService;
        private readonly IExamsService examsService;
        public HomeController(
            ICoursesService coursesService,
            IExamsService examsService
            )
        {
            this.coursesService = coursesService;
            this.examsService = examsService;
        }
        public async Task<IActionResult> Index()
        {
            /*List<Course> coursesList = await coursesService.Courses
            .Include(course => course.Exams)
            .ToListAsync();*/

            IEnumerable<Course> coursesList = await coursesService.List();
            return View(coursesList);
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

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> New(CourseCreationData data)
        {
            if (ModelState.IsValid)
            {
                Course course = new Course(data.CourseName, data.ProfessorName);
                await coursesService.CreateNewCourse(course);
                return RedirectToAction("Index");
            }
            else
            {
                return View(data);
            }
        }


        public async Task<IActionResult> Register(int id)
        {
            Exam exam = await examsService.GetExamFromID(id);
            return View(exam);
        }
    }
}
