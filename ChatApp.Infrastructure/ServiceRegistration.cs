using ChatApp.Application.Abstractions.Services;
using ChatApp.Infrastructure.Persistance.Contexts;
using ChatApp.Infrastructure.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Infrastructure services


            //persistance services
            services.AddDbContext<ChatAppContext>(x => {
                x.UseSqlServer(configuration.GetConnectionString("MSSQL"));
                }
            );
            
            
            services.AddTransient<IMemberService, MemberService>();
            //services.AddTransient<MessageService>();//interface tanımlanacak


        }
    }
}
