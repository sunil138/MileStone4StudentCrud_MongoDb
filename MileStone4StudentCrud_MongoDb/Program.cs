using MediatR;
using Microsoft.AspNetCore.HttpLogging;
using MileStone4StudentCrud_MongoDb.Models;
using MileStone4StudentCrud_MongoDb.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("swagger", builde =>
    {
        builde.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.Configure<StudentStoreSetting>(builder.Configuration.GetSection("StudentsDataBase"));
builder.Services.AddSingleton<StudentRepository>();
builder.Services.AddMediatR(typeof(StudentRepository).Assembly); 
builder.Services.AddHttpLogging(Logging => { Logging.LoggingFields = HttpLoggingFields.All; });
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null); 

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("swagger");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
