using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UnivDotnetters.DTO;
using Windows.Storage;

namespace UnivDotnetters.ViewModel
{
    /// <summary>  
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        private static IContainer _container;

        static ViewModelLocator()
        {
            //
            // Load config file 
            //
            Uri AppConfigPath = new Uri("ms-appx:///Assets/AppConfig.json");
            Task<string> AppConfigJson = Task.Run(async () =>
            {
                return await FileIO.ReadTextAsync(await StorageFile.GetFileFromApplicationUriAsync(AppConfigPath));
            });
            AppConfig AppConfigData = JsonConvert.DeserializeObject<AppConfig>(AppConfigJson.Result);
            //
            // Configure Autofac
            //
            var builder = new ContainerBuilder();
            AutofacConfiguration.Configure(builder, AppConfigData, ViewModelBase.IsInDesignModeStatic);
            _container = builder.Build();
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(_container));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        //
        // Locate the ViewModel
        //
        public MainViewModel MainViewModelContext => ServiceLocator.Current.GetInstance<MainViewModel>();
        public TestSkinsViewModel TestSkinsViewModelContext => ServiceLocator.Current.GetInstance<TestSkinsViewModel>();
        public CinematicMainViewModel CinematicMainViewModelContext => ServiceLocator.Current.GetInstance<CinematicMainViewModel>();
        public CinematicResultViewModel CinematicResultViewModelContext => ServiceLocator.Current.GetInstance<CinematicResultViewModel>();


    }
}
