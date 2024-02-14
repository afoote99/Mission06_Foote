using Microsoft.AspNetCore.Mvc;
using Mission06_Foote.Models;
using System.Diagnostics;

namespace Mission06_Foote.Controllers
{
    public class HomeController : Controller
    {

        private MovieAdditionContext _context;

        public HomeController(MovieAdditionContext temp) //constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MovieForm response)
        {
            _context.MovieForms.Add(response); // add record to the database
            _context.SaveChanges();

            return View("Confirmation");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
