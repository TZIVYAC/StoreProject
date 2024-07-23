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

            // הוספת שירותים למיכל ההזרקות
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // הוספת AutoMapper באופן ידני
            builder.Services.AddSingleton<IMapper>(provider =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    // הוספת פרופילים כאן
                    cfg.AddProfile<CostumerProfile>();
                    cfg.AddProfile<ProductProfile>();
                });
                return config.CreateMapper();
            });

            //  DbContext הוספת 
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ShopDB")));

            // הוספת UserData למיכל ההזרקות
            builder.Services.AddScoped<ProductData>();
            builder.Services.AddScoped<CostumerData>();

            // הוספת IUserService עם ההטמעה שלו UserService
            builder.Services.AddScoped<ICostumerService, CostumerService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            var app = builder.Build();

            // הגדרת הצנרת של בקשות HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<JWTMiddleware>();
            app.UseMiddleware<PrintFunctionNameMiddleware>();

            //app.Run(async context =>
            //{
            //    context.Response.ContentType = "text/plain";
            //    await context.Response.WriteAsync("ok");
            //});

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
   
        }
    }
}