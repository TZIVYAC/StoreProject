using AutoMapper;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using BL.Interfaces;
using BL.Services;
using DAL.Data;
using DAL.Profilies;
using MODELS.Models;
using BL;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(CultureInfo.InvariantCulture);
            });

            // adding services to the injection tank
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // adding an autoMapper manually
            builder.Services.AddSingleton<IMapper>(provider =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    // adding profiles
                    cfg.AddProfile<CostumerProfile>();
                    cfg.AddProfile<ProductProfile>();
                });
                return config.CreateMapper();
            });

            //  adding a DbContext
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ShopDB")));

            // adding an UserData to the injection tank
            builder.Services.AddScoped<ProductData>();
            builder.Services.AddScoped<CostumerData>();

            // adding an IUserService with an UserService
            builder.Services.AddScoped<ICostumerService, CostumerService>();
            builder.Services.AddScoped<IProductService, ProductService>();


            var jwtIssuer = builder.Configuration["Jwt:Issuer"];
            //var jwtKey = builder.Configuration["Jwt:Key"];
            var jwtKey = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            // checking the values
            if (string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtKey))
            {
                throw new ArgumentNullException("JWT settings are not configured properly.");
            }

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                };
            });

            builder.Services.AddAuthorization();
            //jwt for swagger
            builder.Services.AddSwaggerGen(op =>
            {
                op.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                op.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference=new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                             Id="Bearer"
                          }
                    },
                    new string[]{}
                }
            });
            });

            var app = builder.Build();

            // configuring the http request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<JWTMiddleware>();
            app.UseMiddleware<PrintFunctionNameMiddleware>();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
   
        }
    }
}