using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Playstation.Application.Common;
using Playstation.Application.Helpers.GenerateJwt;
using Playstation.Application.MappingProfiles;
using Playstation.Application.Services;
using Playstation.Application.Services.Impl;

namespace Playstation.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEviroment env, IConfiguration configuration)
        {
            services.AddServices(env);

            services.RegisterAutoMapper();

            services.RegisterCashing();

            services.Configure<JwtOption>(configuration.GetSection("JwtSettings"));

            return services;
        }

        private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingSnackService, BookingSnackService>();
            services.AddScoped<ISnackService, SnackService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPlayStationRoomService, PlayStationRoomService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPlayStationRoomGameService, PlayStationRoomGameService>();


          
        }
        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IMappingProfilesMarker));
        }


        private static void RegisterCashing(this IServiceCollection services)
        {
            services.AddMemoryCache();
        }

        public static void AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("SmtpSettings").Get<SmtpSettings>());
        }
    }

}
