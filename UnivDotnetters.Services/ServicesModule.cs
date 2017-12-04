using Autofac;
using UnivDotnetters.IServices;

namespace UnivDotnetters.Services
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
