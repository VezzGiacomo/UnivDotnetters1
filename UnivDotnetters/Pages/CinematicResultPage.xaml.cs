using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using UnivDotnetters.ViewModel;
using Windows.UI.Xaml.Controls;

namespace UnivDotnetters.Pages
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CinematicResultPage : Page
    {
        public CinematicResultViewModel Vm => (CinematicResultViewModel)DataContext;

        public CinematicResultPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (Vm != null && e != null && e.Parameter != null)
                Vm.ReceivingParameter(e.Parameter);
        }

    }
}
