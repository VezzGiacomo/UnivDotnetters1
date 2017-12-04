using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using UnivDotnetters.ViewModel;
using Windows.UI.Xaml.Controls;
using UnivDotnetters.DTO;

namespace UnivDotnetters.Pages
{
    public sealed partial class CinematicMainPage : Page
    {
        public CinematicMainViewModel Vm => (CinematicMainViewModel)DataContext;

        public CinematicMainPage()
        {
            this.InitializeComponent();
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (FilmDTO peli in e.RemovedItems)
            {
                peli.IsSelectedItem = false;
            }

            foreach (FilmDTO peli in e.AddedItems)
            {
                peli.IsSelectedItem = true;
            }
        }
    }
}
