using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Ratings = _context.Ratings
                .OrderBy(x => x.RatingName).ToList();

            return View(new MovieForm());
        }

        [HttpPost]
        public IActionResult AddMovie(MovieForm response)
        {
            if (ModelState.IsValid)
            {
                _context.MovieForms.Add(response); // add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Ratings = _context.Ratings
                    .OrderBy(x => x.RatingName).ToList();

                return View(response);
            }

        }

        public IActionResult MovieQueue()
        {
            var movies = _context.MovieForms
                .OrderBy(x => x.Title).ToList();

            return View(movies);
        }

        //setting the Edit IActionResult
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.MovieForms
                .Single(x => x.MovieId == id);

            ViewBag.Ratings = _context.Ratings
                .OrderBy(x => x.RatingName).ToList();

            return View("AddMovie", recordToEdit);

        }
        [HttpPost]
        public IActionResult Edit(MovieForm updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieQueue");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.MovieForms
                .Single(x => x.MovieId == id);

            ViewBag.Ratings = _context.Ratings
            .OrderBy(x => x.RatingName).ToList();

            return View("Deletion", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(MovieForm deletedInfo)
        {
            _context.MovieForms.Remove(deletedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieQueue");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
