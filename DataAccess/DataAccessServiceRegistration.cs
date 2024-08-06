using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataAccessServiceRegistration 
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DutyManagementContext>(options => options.UseSqlServer(configuration.GetConnectionString("DutyManagementDBContext")));
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<IDutyDal, EfDutyDal>();
            services.AddScoped<IUserOperationClaimDal, EfUserOperationClaimDal>();
            services.AddScoped<IOperationClaimDal, EfOperationClaimDal>();


            return services;
        }
    }
}
