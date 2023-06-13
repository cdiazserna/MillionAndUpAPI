using Microsoft.EntityFrameworkCore;
using MillionAndUp.Data;
using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Domain.Repositories;
using MillionAndUp.Domain.UnitsOfWork;
using MillionAndUp.Helpers;
using MillionAndUp.Helpers.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add services to the container.
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPropertiesUnitOfWork,PropertiesUnitOfWork>();
builder.Services.AddScoped<IDBHelper, DBHelper>();
builder.Services.AddScoped<IPropertyImageUnitOfWork, PropertyImageUnitOfWork>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
