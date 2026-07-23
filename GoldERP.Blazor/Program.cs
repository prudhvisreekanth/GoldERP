using GoldERP.Blazor.Components;
using GoldERP.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddCircuitOptions(options =>
    {
        options.DetailedErrors = true;
    });

//builder.Services.AddScoped(sp => new HttpClient
//{
//    BaseAddress = new Uri("http://localhost:5194/")
//});

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://golderp-1.onrender.com")
});

builder.Services.AddScoped<GoldRateApiService>();
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
