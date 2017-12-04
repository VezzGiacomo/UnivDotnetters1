using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using UnivDotnetters.IServices;

namespace UnivDotnetters.Services.Mock
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // TODO Automate name convention
            //
            builder.RegisterType<CinemaSrv>().As<ICinemaSrv>();
            builder.RegisterType<FindEntradaBagSrv>().As<IFindEntradaBagSrv>();
            builder.RegisterType<FindEntradaSrv>().As<IFindEntradaSrv>();
        }
    }
}
