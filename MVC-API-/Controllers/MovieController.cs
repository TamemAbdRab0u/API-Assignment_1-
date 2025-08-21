using Microsoft.AspNetCore.Mvc;
using MVC_API_.Models;
using System.Net.Http;

namespace MVC_API_.Controllers
{
    public class MovieController : Controller
    {
        private readonly HttpClient httpclient;

        public MovieController(IHttpClientFactory factory)
        {
            httpclient = factory.CreateClient("API-Assignment_1-");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Movie> movies = await httpclient.GetFromJsonAsync<List<Movie>>("Movie");
            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            Movie movie = await httpclient.GetFromJsonAsync<Movie>($"Movie/{Id}");
            return View("Details",movie);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Movie movie)
        {
            var create = await httpclient.PostAsJsonAsync("Movie", movie);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var movie = await httpclient.GetFromJsonAsync<Movie>($"Movie/{Id}");
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Movie movie)
        {
            var update = await httpclient.PutAsJsonAsync("Movie", movie);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var movie = await httpclient.GetFromJsonAsync<Movie>($"Movie/{Id}");
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> SaveDelete(int id)
        {
            var response = await httpclient.DeleteAsync($"Movie/{id}");
            return RedirectToAction("Index");
        }
    }
}
