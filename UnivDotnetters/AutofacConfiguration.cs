using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnivDotnetters.DTO;

namespace UnivDotnetters
{
    public static class AutofacConfiguration
    {
        public static void Configure(ContainerBuilder builder, AppConfig appConfig, bool IsInDesignModeStatic)
        {
            //
            // Instancia de configuración
            //
            builder.RegisterInstance(appConfig).As<AppConfig>();
            
            //
            // Aplication service
            //
            builder.RegisterModule<AppModule>();

            //
            // Data Services
            //
            if (IsInDesignModeStatic || appConfig.UseDesignTimeData)
            {
                builder.RegisterModule<Services.Mock.ServicesModule>();
            }
            else
            {
                builder.RegisterModule<Services.ServicesModule>();
            }
        }
    }
}
