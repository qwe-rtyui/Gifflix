using Gifflix.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class MovieService
{
    private readonly HttpClient _httpClient;

    public MovieService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<MovieResponse> GetPopularMoviesAsync(string search)
    {
        var response = await _httpClient.GetFromJsonAsync<MovieResponse>(search);

        if (response != null)
        {
            foreach (var movie in response.Results)
            {
                Console.WriteLine($"Title: {movie.Title}, PosterPath: {movie.PosterPath}");
            }
        }

        return response;
    }
}
