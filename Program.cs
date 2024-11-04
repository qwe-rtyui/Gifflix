using Gifflix.Components;
using Gifflix.Service;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Carrega as configurações do appsettings.json
builder.Configuration.AddJsonFile("config.json", optional: false, reloadOnChange: true);

// Configura serviços do Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configura HttpClient para TMDb com token do arquivo de configuração
builder.Services.AddHttpClient("TMDbClient", client =>
{
    client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
    var token = builder.Configuration["TMDb:BearerToken"];
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
});

// Configura HttpClient para Giphy
builder.Services.AddHttpClient("GiphyClient", client =>
{
    client.BaseAddress = new Uri("https://api.giphy.com/v1/");
});

// Registra os serviços MovieService e GiphyService
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<GiphyService>();

var app = builder.Build();

// Configuração do pipeline de requisição HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
