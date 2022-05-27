global using BlazorAppQLDT.Client.Services.SuperHeroService;
global using BlazorAppQLDT.Client.Services.SinhvienService;
global using BlazorAppQLDT.Client.Services.SinhvienCD18Service;
global using BlazorAppQLDT.Client.Services.SinhvienCD15Services;
global using BlazorAppQLDT.Client.Services.ExcelService;
global using BlazorAppQLDT.Shared;
global using System.Net.Http.Json;
using BlazorAppQLDT.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("BlazorAppQLDT.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorAppQLDT.ServerAPI"));
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddScoped<ISinhvienService, SinhvienService>();
builder.Services.AddScoped<ISinhvienCD18Service, SinhvienCD18Service>();
builder.Services.AddScoped<ISinhvienCD15Service, SinhvienCD15Service>();
builder.Services.AddScoped<IExcelService, ExcelService>();
builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
