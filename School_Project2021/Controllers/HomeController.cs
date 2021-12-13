using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School_Project2021.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace School_Project2021.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        VideoContext db;

        public static string currentLayout= "_adminLayout";
        public HomeController(ILogger<HomeController> logger, VideoContext context)
        {
            _logger = logger;
            db = context;
            currentLayout = "_Layout";
        }

        public IActionResult Index()
        {
            var courses = db.Courses.ToList<Course>();
            return View(courses);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Contact_Post(ContactUs newMessage)
        {
            db.Contacts.Add(newMessage);
            db.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Team()
        {
            return View();
        }
        public IActionResult Course(int id)
        {
            ViewBag.courseName = db.Courses.Find(id).Name;
            ViewBag.courseDiscraption = db.Courses.Find(id).Discraption;
            var videos= db.Videos.Where(x => x.CourseID == id).ToList();

            return View(videos);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
