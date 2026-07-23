using FluentValidation;
using GoldERP.API.Middleware;
using GoldERP.Application.Behaviors;
using GoldERP.Application.Features.GoldRate.Queries;
using GoldERP.Application.Interfaces;
using GoldERP.Infrastructure.External.Currency;
using GoldERP.Infrastructure.External.GoldApi;
using GoldERP.Infrastructure.Services;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetLiveGoldRateQuery).Assembly);
});
builder.Services.AddValidatorsFromAssembly(typeof(GetLiveGoldRateQuery).Assembly);
builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));
builder.Services.AddHttpClient<IGoldApiClient, GoldApiClient>();
builder.Services.AddScoped<IGoldRateService, GoldRateService>();
builder.Services.AddHttpClient<ICurrencyService, CurrencyService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Blazor", policy =>
    {
        policy.WithOrigins("https://localhost:7132") // Blazor URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseExceptionHandlingMiddleware();
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("Blazor");
app.MapControllers();

app.Run();