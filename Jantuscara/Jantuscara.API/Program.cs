using Jantuscara.API;
using Microsoft.EntityFrameworkCore;
using Jantuscara.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=localhost;Database=jantuscaradb;Uid=root;Pwd=root;";
//var connectionString = "Server=empeldb.mysql.database.azure.com;Database=empeldb;Uid=empel;Pwd=eml@1234;";

// Add services to the container.

builder.Services.AddDbContext<MySqlDbContext>(options =>
options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString))
);

DependencyInjection.Register(builder.Services);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
