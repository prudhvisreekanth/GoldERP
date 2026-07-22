using GoldERP.Application.Interfaces;
using GoldERP.Application.Features.GoldRate.Queries;
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
builder.Services.AddHttpClient<IGoldApiClient, GoldApiClient>();
builder.Services.AddScoped<IGoldRateService, GoldRateService>();
builder.Services.AddHttpClient<ICurrencyService, CurrencyService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();