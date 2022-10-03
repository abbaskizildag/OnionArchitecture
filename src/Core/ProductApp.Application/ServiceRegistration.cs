using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection service)
        {
            var assm = Assembly.GetExecutingAssembly();
            service.AddAutoMapper(assm);
            service.AddMediatR(assm);
        }
    }
}
