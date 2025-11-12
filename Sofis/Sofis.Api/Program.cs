using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Sofis.Api.Application;
using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Application.Services;
using Sofis.Api.Infrastructure;
using Sofis.Api.Infrastructure.Persistence.Repositories;
using Sofis.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(80);
//});
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Add services to the container.
//builder.Services.AddScoped<IChildRepository, ChildRepository>();
//builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//builder.Services.AddScoped<IFamilyRepository, FamilyRepository>(); 

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

//builder.Services.AddScoped<IChildService, ChildService>();
//builder.Services.AddScoped<IEmployeeService, EmployeeService>();
//builder.Services.AddScoped<IPasswordService, PasswordService>();
//builder.Services.AddScoped<IFamilyService, FamilyService>();
//builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SofisDbContext>(options =>
    options.UseNpgsql(connectionString,
    npgsqlOptions => npgsqlOptions.EnableRetryOnFailure(
        maxRetryCount: 10,
        maxRetryDelay: TimeSpan.FromSeconds(15),
        errorCodesToAdd: null
    )));

var app = builder.Build();

app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();


app.MapControllers();

app.Run();
