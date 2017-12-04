﻿using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using UnivDotnetters.ViewModel;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace UnivDotnetters.Pages
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class TestSkinsPage : Page
    {
        public TestSkinsViewModel Vm => (TestSkinsViewModel)DataContext;

        public TestSkinsPage()
        {
            this.InitializeComponent();
        }
    }
}
