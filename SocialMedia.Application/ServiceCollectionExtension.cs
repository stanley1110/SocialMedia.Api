using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Application.Interface;
using SocialMedia.Infrastructure.Interface;
using SocialMedia.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

namespace SocialMedia.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSocialMediaServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetEntryAssembly()));

            services.AddMemoryCache();
        }
    }
}
