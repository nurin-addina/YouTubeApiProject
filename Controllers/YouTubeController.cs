using Microsoft.AspNetCore.Mvc;
using YouTubeApiProject.Services;
using YouTubeApiProject.Models;
namespace YouTubeApiProject.Controllers
{
    public class YouTubeController : Controller
    {
        private readonly YouTubeApiService _youtubeService;
        public YouTubeController(YouTubeApiService
       youtubeService)
        {
            _youtubeService = youtubeService;
        }
        // Display Search Page
        public IActionResult Index()
        {
            return View(new List<YouTubeVideoModel>());
        }
        // Handle search query
        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            var videos = await
           _youtubeService.SearchVideosAsync(query);
            return View("Index", videos);
        }
    }
}