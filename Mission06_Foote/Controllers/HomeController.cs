using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Foote.Models;
using System.Diagnostics;

namespace Mission06_Foote.Controllers
{
    public class HomeController : Controller
    {
        //Loading data into context
        private MovieAdditionContext _context;

        public HomeController(MovieAdditionContext temp) //constructor
        {
            _context = temp;
        }

        //What to do when Index page is accessed 
        public IActionResult Index()
        {
            return View();
        }

        //what to do when GetToKnow page is accessed 
        public IActionResult GetToKnow()
        {
            return View();
        }

        //Get moethod for when someone goes to the AddMovie page
        [HttpGet]
        public IActionResult AddMovie()
        {
            //Load the categories into a viewbag for easy access
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName).ToList();

            return View(new MovieForm());
        }

        //Post method for adding a movie
        [HttpPost]
        public IActionResult AddMovie(MovieForm response)
        {
            //if all the entries are valid, run smoothly
            if (ModelState.IsValid)
            {
                _context.MovieForms.Add(response); // add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else // reload page with already filled out info
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(c => c.CategoryName).ToList();

                return View(response);
            }

        }

        //what to run when someone is trying to look at the Movie list
        public IActionResult MovieQueue()
        {
            var movies = _context.MovieForms
                .Include(m => m.Categories) // Eagerly load Categories with each MovieForm
                .OrderBy(c => c.Title)
                .ToList();

            return View(movies);
        }

        //What to do when editing records
        public IActionResult Edit(int id)
        {
            //grabs the right record based on ID to edit
            var recordToEdit = _context.MovieForms
                .Single(c => c.MovieId == id);

            //uses viewbag to access category info
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName).ToList();

            return View("AddMovie", recordToEdit);

        }

        //Post the changes and save them
        [HttpPost]
        public IActionResult Edit(MovieForm updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieQueue");
        }

        //similar to what we did for the dit, but now it's just for delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.MovieForms
                .Single(c => c.MovieId == id);

            ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName).ToList();

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
