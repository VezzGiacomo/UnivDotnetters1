using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using UnivDotnetters.IServices;
using UnivDotnetters.DTO;
using System.Collections.Generic;
using CommonServiceLocator;

namespace UnivDotnetters.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ICinemaSrv _cinemaSrv;

        private readonly INavigationService _navigationService;
        private string _clock = "Starting...";
        private int _counter;
        private RelayCommand _incrementCommand;
        private RelayCommand<string> _navigateCommand;
        private bool _runClock;
        private RelayCommand _sendMessageCommand;
        private RelayCommand _testServicesCommand;
        private RelayCommand _showDialogCommand;
        private string _welcomeTitle = string.Empty;

        public string Clock
        {
            get
            {
                return _clock;
            }
            set
            {
                Set(ref _clock, value);
            }
        }

        public RelayCommand IncrementCommand
        {
            get
            {
                return _incrementCommand
                    ?? (_incrementCommand = new RelayCommand(
                    () =>
                    {
                        WelcomeTitle = string.Format("Counter clicked {0} times", ++_counter);
                    }));
            }
        }

        public RelayCommand<string> NavigateCommand
        {
            get
            {
                return _navigateCommand ?? (_navigateCommand = new RelayCommand<string>(
                    ExecuteNavigateCommand,
                    CanExecuteNavigateCommand));
            }
        }
        private void ExecuteNavigateCommand(string parameter)
        {
            if (!string.IsNullOrWhiteSpace(parameter))
                _navigationService.NavigateTo(parameter, null);
        }
        private bool CanExecuteNavigateCommand(string parameter)
        {
            return !string.IsNullOrWhiteSpace(parameter);
        }

        public RelayCommand TestServicesCommand
        {
            get
            {
                return _testServicesCommand ?? (_testServicesCommand = new RelayCommand(ExecuteTestServicesCommand));
            }
        }
        private void ExecuteTestServicesCommand()
        {
            try
            {
                Task<List<CinemaDTO>> _data = Task.Run(async () =>
                {
                    return await _cinemaSrv.GetCinemas();
                });
                if (_data != null && _data.Result != null && _data.Result.Count > 0)
                    TestServicesResult = _data.Result[0].Name;
            }
            catch (Exception ex)
            {
                throw(ex);
            }           
        }

        private string _testServicesResult = string.Empty;
        public string TestServicesResult
        {
            get
            {
                return _testServicesResult;
            }

            set
            {
                if (_testServicesResult == value)
                {
                    return;
                }
                var oldValue = _testServicesResult;
                _testServicesResult = value;
                RaisePropertyChanged("TestServicesResult", oldValue, value, true);
            }
        }

        public RelayCommand SendMessageCommand
        {
            get
            {
                return _sendMessageCommand
                    ?? (_sendMessageCommand = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send(
                            new NotificationMessageAction<string>(
                                "Testing",
                                reply =>
                                {
                                    WelcomeTitle = reply;
                                }));
                    }));
            }
        }

        public RelayCommand ShowDialogCommand
        {
            get
            {
                return _showDialogCommand
                       ?? (_showDialogCommand = new RelayCommand(
                           async () =>
                           {
                               var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                               await dialog.ShowMessage("Hello Universal Application", "it works...");
                           }));
            }
        }

        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        public MainViewModel(
            ICinemaSrv cinemaSrv,
            INavigationService navigationService)
        {
            _cinemaSrv = cinemaSrv;
            _navigationService = navigationService;
        }

        public void RunClock()
        {
            _runClock = true;

            Task.Run(async () =>
            {
                while (_runClock)
                {
                    try
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(() =>
                        {
                            Clock = DateTime.Now.ToString("HH:mm:ss");
                        });

                        await Task.Delay(1000);
                    }
                    catch (Exception)
                    {
                    }
                }
            });
        }

        public void StopClock()
        {
            _runClock = false;
        }

    }
}