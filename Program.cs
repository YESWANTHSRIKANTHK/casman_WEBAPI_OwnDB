using casman_WEBAPI.Models;
using casman_WEBAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<CaseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CaseConnection")));

// Add Repository
builder.Services.AddScoped<ICaseRepository, CaseRepository>();

// Add CORS (for React frontend)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000") // React app
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add Controllers with camelCase JSON config
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(); // Enable CORS
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
