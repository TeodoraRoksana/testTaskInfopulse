using Microsoft.EntityFrameworkCore;
using TestTask.API.Services.DBService;
using TestTask.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TestTaskContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainDB")));
builder.Services.AddCors(options => options.AddPolicy(name: "TestTaskOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));
builder.Services.AddScoped<IDBService, DBService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("TestTaskOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
