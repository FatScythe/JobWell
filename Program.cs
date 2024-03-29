using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using server.Data;
using server.Interface;
using server.Models;
using server.Repository;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<Account>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();

//builder.Services.AddIdentity<Account, IdentityRole>(options =>
//{
//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequiredLength = 12;
//    options.User.RequireUniqueEmail = true;
//}).AddEntityFrameworkStores<DbContext>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IJobRepository, JobRepository>();
var app = builder.Build();

app.MapIdentityApi<Account>();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();