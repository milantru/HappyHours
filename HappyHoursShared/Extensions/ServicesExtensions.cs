using HappyHoursShared.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHoursShared.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddHappyHoursServices(this IServiceCollection services)
        {
            services.AddSingleton<UserService>();
        }
    }
}
