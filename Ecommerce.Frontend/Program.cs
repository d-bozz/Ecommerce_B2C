using Ecommerce.Frontend;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Blazored.LocalStorage;
using Blazored.Toast;

using Microsoft.Identity.Client;
using Ecommerce.Frontend.Services.Contrat;
using Ecommerce.Frontend.Services.Implementation;

using CurrieTechnologies.Razor.SweetAlert2;

using Microsoft.AspNetCore.Components.Authorization;
using Ecommerce.Frontend.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5292/api/") });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<ICarritoService, CarritoService>();
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IWishlistService, WishlistService>();

builder.Services.AddSweetAlert2();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationExtension>();

await builder.Build().RunAsync();
