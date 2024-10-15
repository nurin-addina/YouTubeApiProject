using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using YouTubeApiProject.Models;
namespace YouTubeApiProject.Services
{
    public class YouTubeApiService
    {
        private readonly string _apiKey;
        public YouTubeApiService(IConfiguration configuration)
        {
            _apiKey = configuration["YouTubeApiKey"];
        }
        public async Task<List<YouTubeVideoModel>>
       SearchVideosAsync(string query)
        {
            var youtubeService = new YouTubeService(new
           BaseClientService.Initializer()
            {
                ApiKey = _apiKey,
                ApplicationName = "YouTubeApiProject"
            });
            var searchRequest =
           youtubeService.Search.List("snippet");
            searchRequest.Q = query;
            searchRequest.MaxResults = 10;
            var searchResponse = await
           searchRequest.ExecuteAsync();
            var videos = searchResponse.Items.Select(item => new
           YouTubeVideoModel
            {
                Title = item.Snippet.Title,
                Description = item.Snippet.Description,
                ThumbnailUrl = item.Snippet.Thumbnails.Medium.Url,
                VideoUrl = "https://www.youtube.com/watch?v=" + item.Id.VideoId // Add this line
            }).ToList();
            return videos;
        }
    }
}