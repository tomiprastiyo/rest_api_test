using Microsoft.EntityFrameworkCore;
using rest_api_test;
using rest_api_test.Applications;

var builder = WebApplication.CreateBuilder(args);

DbInitializer.Initialize();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<rest_api_test_db>(options =>
{
    options.UseMySql(AppGlobal.GetConnectionString(), new MySqlServerVersion(new Version()));
});

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
