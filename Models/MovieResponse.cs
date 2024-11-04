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

        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; }  // banner

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public double Popularity { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public List<Genre> Genres { get; set; }
        public string OriginalLanguage { get; set; }
        public string Tagline { get; set; }
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public string Homepage { get; set; }
        public string Status { get; set; }

        public string FullPosterPath => !string.IsNullOrEmpty(PosterPath)
        ? $"https://image.tmdb.org/t/p/w500{PosterPath}"
        : "https://via.placeholder.com/500x750?text=No+Image";

        // banner
        public string FullbackdropUrl => !string.IsNullOrEmpty(BackdropPath)
        ? $"https://image.tmdb.org/t/p/original{BackdropPath}"
        : "https://via.placeholder.com/500x750?text=No+Image";

        

    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductionCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public string OriginCountry { get; set; }
    }
        
    public class GenreResponse
    {
        public List<Genre> Genres { get; set; }
    }

    public class antigo
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
