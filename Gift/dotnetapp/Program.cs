// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;
// using Microsoft.EntityFrameworkCore;
// using dotnetapp.Data;
// using dotnetapp.Services;
// using dotnetapp.Repositories;
// using System.Text;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(builder =>
//     {
//         builder.AllowAnyOrigin()
//                .AllowAnyHeader()
//                .AllowAnyMethod();
//     });
// });

// // Add DbContext registration
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("Gift")));

// // Add repositories and services
// builder.Services.AddScoped<UserRepository>();
// builder.Services.AddScoped<GiftService, GiftServiceImpl>();

// builder.Services.AddScoped<UserService, UserServiceImpl>();

// // Add JWT authentication
// var key = Encoding.ASCII.GetBytes("MySuperSecretKey123!$%^&*");
// builder.Services.AddAuthentication(x =>
// {
//     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(x =>
// {
//     x.RequireHttpsMetadata = false;
//     x.SaveToken = true;
//     x.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(key),
//         ValidateIssuer = false,
//         ValidateAudience = false
//     };
// });

// // Authorization policies
// builder.Services.AddAuthorization(options =>
// {
//     options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
//     // Add other policies as needed
// });

// // Add other services if you have them

// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();
// app.UseCors();
// app.UseAuthentication();  // Add this line for JWT authentication
// app.UseAuthorization();   // Add this line for JWT authorization
// app.MapControllers();
// app.Run();



using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Data;
using dotnetapp.Services;
using dotnetapp.Repositories;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });

        // Add DbContext registration
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Gift")));

        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<GiftRepository>();  // Add this line for GiftRepository
        builder.Services.AddScoped<GiftService, GiftServiceImpl>();
        builder.Services.AddScoped<UserService, UserServiceImpl>();
        // Add JWT authentication
        var key = Encoding.ASCII.GetBytes("MySuperSecretKey123!$%^&*");
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        // Authorization policies
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            // Add other policies as needed
        });

        // Add other services if you have them

        builder.Services.AddControllers();
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
        app.UseCors();
        app.UseRouting();

        app.UseAuthentication();  // Add this line for JWT authentication
        app.UseAuthorization();   // Add this line for JWT authorization

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}
