using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using UnivDotnetters.IServices;

namespace UnivDotnetters.ViewModel
{
    public class TestSkinsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;


        public TestSkinsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
       
        private string _textTestProp = string.Empty;
        public string TextTestProp
        {
            get
            {
                return _textTestProp;
            }

            set
            {
                if (_textTestProp == value)
                {
                    return;
                }
                var oldValue = _textTestProp;
                _textTestProp = value;
                RaisePropertyChanged("TextTestProp", oldValue, value, true);
            }
        }


        private RelayCommand<string> _goBackCommand;
        public RelayCommand<string> GoBackCommand
        {
            get
            {
                return _goBackCommand ?? (_goBackCommand = new RelayCommand<string>(
                    ExecuteGoBackCommand,
                    CanExecuteGoBackCommand));
            }
        }

        private void ExecuteGoBackCommand(string parameter)
        {
            _navigationService.GoBack();
        }

        private bool CanExecuteGoBackCommand(string parameter)
        {
            //return !string.IsNullOrWhiteSpace(parameter);
            return true;
        }




    }
}
