using IBBNesine.Services.Abstract;
using IBBNesine.Services.Services;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection("Server=NSN-FOZDURAN\\SQLEXPRESS;Database=dapper;Trusted_connection=True;MultipleActiveResultSets=true;"));

builder.Services.AddScoped<IParkService, ParkService>();

// Add services to the container.

builder.Services.AddControllers();
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
