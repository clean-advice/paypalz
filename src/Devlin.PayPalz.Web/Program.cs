using Devlin.PayPalz.TaxCalculationApi;
using Devlin.PayPalz.Web;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.
services.AddRazorPages()
        .AddNewtonsoftJson();
builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

// Add services to the container.
services.AddHttpClient("TaxCalculationApi", httpClient =>
{
    httpClient.BaseAddress = new Uri(configuration["TaxCalculationApiClient:host"]);
    // Add token support
    // using Microsoft.Net.Http.Headers;
    // httpClient.DefaultRequestHeaders.Add(
    //    HeaderNames.Accept, configuration["API_TOKEN"]);;
});

var taxCalculationApiHost = configuration["TaxCalculationApiClient:host"];
services.AddHttpClient<ITaxCalculationApiClient, TaxCalculationApiClient>(
    client => client.BaseAddress = new Uri(taxCalculationApiHost));

services.AddTaxCalculationApiClient(httpClient =>
{
    httpClient.BaseAddress = new(taxCalculationApiHost);
    //httpClient.AddHeaders(host, configuration["API_TOKEN"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
