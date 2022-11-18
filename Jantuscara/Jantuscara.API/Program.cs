using Jantuscara.API;
using Microsoft.EntityFrameworkCore;
using Jantuscara.Repository;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=localhost;Database=jantuscaradb;Uid=root;Pwd=root;";
//var connectionString = "Server=empeldb.mysql.database.azure.com;Database=empeldb;Uid=empel;Pwd=eml@1234;";

// Add services to the container.

builder.Services.AddDbContext<MySqlDbContext>(options =>
options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Jantuscara REST Api",
            Version = "v1",
            Description = "Esta API provem recursos para os Clients Jantuscara."
        });
});

DependencyInjection.Register(builder.Services);

// Cors configurations
builder.Services.AddCors(opt => opt.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
})); // ---------- Cors configurations

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint(
        "/swagger/v1/swagger.json",
        "Jantuscara REST Api - v1");
});

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

app.UseAuthorization();

app.MapControllers();

app.Run();
