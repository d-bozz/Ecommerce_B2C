using Ecommerce.Repository.Contract;
using Ecommerce.Repository.DBContext;
using Ecommerce.Repository.Implementation;
using Ecommerce.Utilities;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Services.Contract;
using Ecommerce.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EcommerceB2cContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Ecommerce_SQL"));
});

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IVentaRepository, VentaRepository>();

builder.Services.AddAutoMapper(typeof(AutomapperProfile));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IWishlistService, WishlistService>();

builder.Services.AddCors(options=>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NewPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
