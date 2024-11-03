using System.Text.Json.Serialization;

namespace Gifflix.Models
{
    public class MovieResponse
    {
        public int Page { get; set; }
        public List<Movie> Results { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        public string FullPosterPath => !string.IsNullOrEmpty(PosterPath)
    ? $"https://image.tmdb.org/t/p/w500{PosterPath}"
    : "https://via.placeholder.com/500x750?text=No+Image";
    }

}
