using CubatelToDoListApp.Business.Services;
using CubatelToDoListApp.Contracts.Services;
using CubatelToDoListApp.DataService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Agregando Los Servicios
builder.Services.AddScoped<IToDoListService, ToDoListService>();

//Agregando Conexi�n Con la DB

string dbConnection = builder.Configuration.GetConnectionString("MySQLDB");

builder.Services.AddDbContext<CubatelMySQLContext>(ops => ops.UseMySql(
        dbConnection,
        ServerVersion.AutoDetect(dbConnection)
    ));

//AutoMappers
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.MapControllers();

app.Run();
