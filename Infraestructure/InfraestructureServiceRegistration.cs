using Application.Contracts.Persistence;
using Data;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public static class InfraestructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddDbContext<CandidateDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            //);

            services.AddDbContext<CandidateDbContext>(options =>
 options.UseSqlServer(configuration.GetConnectionString("CandidateConnection")));



            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddTransient<ICandidateRepository, CandidateRepository>();
            services.AddTransient<ICandidateExperienceRepository, CandidateExperienceRepository>();

            return services;
        }
    }
}
