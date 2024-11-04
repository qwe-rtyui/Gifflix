using Gifflix.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class MovieService
{
    private readonly HttpClient _httpClient;

    public MovieService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("TMDbClient");
    }

    public async Task<MovieResponse> GetPopularMoviesAsync(string search)
    {
        var response = await _httpClient.GetFromJsonAsync<MovieResponse>("movie/popular?language=en-US&page=1");

        if (response != null)
        {
            foreach (var movie in response.Results)
            {
                Console.WriteLine($"Title: {movie.Title}, PosterPath: {movie.PosterPath}");
            }
        }

        return response;
    }

    public async Task<Movie> GetMovieDetailsAsync(int movieId)
    {
        // Chama o endpoint para obter um filme específico
        var movie = await _httpClient.GetFromJsonAsync<Movie>($"movie/{movieId}?language=en-US");

        if (movie != null)
        {
            Console.WriteLine($"Title: {movie.Title}, PosterPath: {movie.PosterPath}");
        }

        return movie;
    }

    public async Task<List<Genre>> GetGenresAsync()
    {
        // Chama o endpoint de gêneros
        var genreResponse = await _httpClient.GetFromJsonAsync<GenreResponse>("genre/movie/list?language=en-US");

        return genreResponse?.Genres ?? new List<Genre>();
    }

    public async Task<List<Movie>> GetMoviesByGenreAsync(int genreId)
    {
        // Monta a URL com o filtro de gênero
        var url = $"discover/movie?with_genres={genreId}&language=en-US";

        // Faz a requisição e obtém a resposta
        var movieResponse = await _httpClient.GetFromJsonAsync<MovieResponse>(url);

        return movieResponse?.Results ?? new List<Movie>();
    }

}
