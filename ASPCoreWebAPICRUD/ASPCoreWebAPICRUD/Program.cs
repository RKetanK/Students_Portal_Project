using ASPCoreWebAPICRUD.Models;//1.Demo_dbContext comes from this namespace/folder
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//regestering the service provider before the build of app
var provider = builder.Services.BuildServiceProvider();//2
var config = provider.GetRequiredService<IConfiguration>();
//here use the name of class which inherits the DbContext class(here, Demo_dbContext)
//also regestering the connection string(here, dbcs)
//this line says that we.re using the SqlServer as a Database provider and getting the connection string
//which contains the server name and database
builder.Services.AddDbContext<Demo_dbContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));//3.
//above 1,2,3 are compulsary for the database connectivity with this project
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
