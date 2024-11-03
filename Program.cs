using Gifflix.Components;
using Gifflix.Service;
using System.Net.Http.Headers;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


// Configuração do HttpClient para a API do TMDb
//builder.Services.AddScoped(sp => {
//    var client = new HttpClient { BaseAddress = new Uri("https://api.themoviedb.org/3/") };
//    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ""); // substitua YOUR_ACCESS_TOKEN pelo seu token
//    return client;
//});

builder.Services.AddHttpClient("TMDbClient", client =>
{
    client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmNDc0ZDU1NjU1NGFjMmI5ZjUxOTE1NjgxMGRjZjZiYSIsIm5iZiI6MTczMDU4NTg0Ni42NTg3ODg0LCJzdWIiOiI2NzI2YTM0YWMwOTAxMDk1ODBmOWMyMTEiLCJzY29wZXMiOlsiYXBpX3JlYWQiXSwidmVyc2lvbiI6MX0.4EZI6PDdMin7XP54vxrA7Z45R9kStQK5ZJpmJVZyoWY");
});

builder.Services.AddHttpClient("GiphyClient", client =>
{
    client.BaseAddress = new Uri("https://api.giphy.com/v1/");
});


builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<GiphyService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
