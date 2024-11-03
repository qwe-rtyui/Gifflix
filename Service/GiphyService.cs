using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gifflix.Service
{
    public class GiphyService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "t16ZR2PbsAEwAxXG3aGVsgkJLjJQRiq9"; // Substitua pela sua chave de API

        public GiphyService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("GiphyClient");
        }

        public async Task<GiphyResponse> SearchGifsAsync(string query)
        {
            // Monta a URL da busca
            var url = $"gifs/search?api_key={_apiKey}&q={query}&limit=10&rating=g";
            return await _httpClient.GetFromJsonAsync<GiphyResponse>(url);
        }
    }

    // Modelos de resposta para a API
    public class GiphyResponse
    {
        [JsonPropertyName("data")]
        public List<GifData> Data { get; set; }
    }

    public class GifData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("images")]
        public GifImages Images { get; set; }
    }

    public class GifImages
    {
        [JsonPropertyName("downsized_medium")]
        public GifImage DownsizedMedium { get; set; }
    }

    public class GifImage
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

}
