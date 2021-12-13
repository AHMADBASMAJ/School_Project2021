using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Project2021.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {

        public AdminController()
        {
            HomeController.currentLayout = "_adminLayout";
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
