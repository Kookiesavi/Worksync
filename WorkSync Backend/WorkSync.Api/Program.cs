
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WorkSync.Application.Interfaces;
using WorkSync.Application.Services;
using WorkSync.Infrastructure.Data;
using WorkSync.Infrastructure.Repositories;



var builder = WebApplication.CreateBuilder(args);

//allow cors to use react app
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddDbContext<WorkSyncDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Authentication will be added later when we implement JWT.
// app.UseAuthentication();


//allow cors to use react app
app.UseCors("AllowReactApp");
app.UseAuthorization();

app.MapControllers();

app.Run();