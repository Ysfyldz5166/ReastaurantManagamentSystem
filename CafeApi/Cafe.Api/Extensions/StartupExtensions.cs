using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Cafe.DataAcces.UnitOfWork;
using Cafe.Repository.Advertisement;
using Cafe.Repository.Advertisements;
using Cafe.Repository.Categories;
using Cafe.Repository.Foods;
using Cafe.Repository.Users;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CafeApi.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // AutoMapper configuration
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //Cors configuration 
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            // MediatR configuration
            var assembly = AppDomain.CurrentDomain.Load("Cafe.BusinessLogic");
            services.AddMediatR(assembly);

            // FluentValidation configuration
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                });



            // Add other services
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<ICategoryReapository, CategoryRepository>();
        }
    }
}
