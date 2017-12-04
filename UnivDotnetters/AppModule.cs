using Autofac;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnivDotnetters.Pages;
using UnivDotnetters.ViewModel;

namespace UnivDotnetters
{
    public class AppModule : Autofac.Module
    {
        public const string TestSkinsPageKey = "TestSkinsPage";
        public const string CinematicMainPageKey = "CinematicMainPage";
        public const string CinematicResultPageKey = "CinematicResultPage";

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Navigation Service
            //
            var nav = new NavigationService();
            nav.Configure(TestSkinsPageKey, typeof(TestSkinsPage));
            nav.Configure(CinematicMainPageKey, typeof(CinematicMainPage));
            nav.Configure(CinematicResultPageKey, typeof(CinematicResultPage));
            builder.RegisterInstance(nav).AsImplementedInterfaces();

            //
            // ViewModels
            //
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<TestSkinsViewModel>();
            builder.RegisterType<CinematicMainViewModel>();
            builder.RegisterType<CinematicResultViewModel>();

            //
            // Dialog Services
            //
            builder.RegisterType<DialogService>().As<IDialogService>();
        }
    }
}
