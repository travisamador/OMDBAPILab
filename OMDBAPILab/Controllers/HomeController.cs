using Microsoft.AspNetCore.Mvc;
using OMDBAPILab.Models;
using System.Diagnostics;

namespace OMDBAPILab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;
        public MovieDAL movieDAL = new MovieDAL();
        

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            movieDAL.APIKey = configuration["APIKey"];
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieSearch(string title)
        {
            MovieModel movie = movieDAL.GetMovie(title);
            return View(movie);
        }

        [HttpGet]
        public IActionResult MovieNight()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieNight(string title1, string title2, string title3)
        {
            List<MovieModel> movieList = new List<MovieModel> {
                movieDAL.GetMovie(title1),
                movieDAL.GetMovie(title2),
                movieDAL.GetMovie(title3)
            };
            return View(movieList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}