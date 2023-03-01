using Microsoft.Extensions.FileProviders;
using UserManagement.Interfaces;
using UserManagement.Models;
using UserManagement.Repositories;
using UserManagement.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<UserManagementDatabaseSettings>(
    builder.Configuration.GetSection("UserManagementDatabase"));

builder.Services.AddSingleton<IDepartmentService, DepartmentService>();
builder.Services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddSingleton<ISiteService, SiteService>();
builder.Services.AddSingleton<ISiteRepository, SiteRepository>();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

// Add services to the container.
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
    RequestPath = "/Photos"
});

app.Run();

