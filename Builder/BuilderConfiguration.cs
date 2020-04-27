using Fleet_Managment_BLL.Interfaces;
using Fleet_Managment_BLL.Services;
using Fleet_Managment_DAL;
using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Builder
{
    public static class BuilderConfiguration
    {
        public static void ConfigureServicesFleetManagment(IServiceCollection services)
        {
            services.AddDbContext<FleetManagmentContext>((options => options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Fleet Managment;Trusted_Connection=True;")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICarService, CarService>();
        }
    }
}