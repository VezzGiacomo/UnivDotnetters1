using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace UnivDotnetters
{
    public interface INavigationEvents
    {
        void ReceivingParameter(Object parameter);
    }
}
