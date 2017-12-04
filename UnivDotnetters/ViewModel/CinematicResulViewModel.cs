using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using UnivDotnetters.DTO;
using Windows.UI.Popups;

namespace UnivDotnetters.ViewModel
{
    public class CinematicResultViewModel : ViewModelBase , INavigationEvents
    {
        private readonly INavigationService _navigationService;

        public CinematicResultViewModel(INavigationService navigationService)
        {
            try
            {
                #region Servicios

                _navigationService = navigationService;

                #endregion

                #region Default property values

                _titlePage = "Sesiones Encontradas";
                //
                // Solo en modo disegno
                //
                if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                {
                    InitDebugPageValues();
                }
                #endregion

                Messenger.Default.Register<List<FindEntradaResultModel>>(this,
                    message =>
                    {
                        if (message != null && message.Any())
                            EntradasResult = new ObservableCollection<FindEntradaResultModel>(message);
                    });

                _editIsEnabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Conditional("DEBUG")]
        private void InitDebugPageValues()
        {
            _entradasResult = new ObservableCollection<FindEntradaResultModel>(new List<FindEntradaResultModel> {
                new FindEntradaResultModel { CinemaName = "Palafox DESIGN", ScreenName = "Aneto DESIGN", FilmName ="Tarzan DESIGN", Start = new DateTime(2017,11,28,16,35,0) },
                new FindEntradaResultModel { CinemaName = "Aragonia DESIGN", ScreenName = "Verde DESIGN", FilmName ="Tarzan DESIGN", Start = new DateTime(2017,11,28,17,35,0) },
                new FindEntradaResultModel { CinemaName = "Cervantes DESIGN", ScreenName = "Aneto DESIGN", FilmName ="Godzilla DESIGN", Start = new DateTime(2017,11,28,18,35,0) },
                new FindEntradaResultModel { CinemaName = "Aragonia DESIGN", ScreenName = "Verde DESIGN", FilmName ="Godzilla DESIGN", Start = new DateTime(2017,11,28,17,50,0) },
            });

            _entradaSel = _entradasResult.First();
        }

        #region INavigationEvents

        private FindEntradaFilterDTO Parameter = null;
        public void ReceivingParameter(Object parameter)
        {
            try
            {
                if (parameter != null && parameter is FindEntradaFilterDTO)
                {
                    Parameter = (FindEntradaFilterDTO)parameter;
                    TitlePage = string.Format("{0} en la fecha {1:yyyy/MM/dd}", TitlePage, (Parameter.Start ?? DateTime.Now));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Binding properties

        private string _titlePage;
        public string TitlePage
        {
            get
            {
                return _titlePage;
            }
            set
            {
                if (_titlePage == value)
                {
                    return;
                }
                var oldValue = _titlePage;
                _titlePage = value;
                RaisePropertyChanged("TitlePage", oldValue, value, true);
            }
        }

        private bool _editIsEnabled;
        public bool EditIsEnabled
        {
            get
            {
                return _editIsEnabled;
            }
            set
            {
                if (_editIsEnabled == value)
                {
                    return;
                }
                var oldValue = _editIsEnabled;
                _editIsEnabled = value;
                RaisePropertyChanged("EditIsEnabled", oldValue, value, true);
            }
        }

        private ObservableCollection<FindEntradaResultModel> _entradasResult = null;
        public ObservableCollection<FindEntradaResultModel> EntradasResult
        {
            get
            {
                return _entradasResult;
            }
            set
            {
                _entradasResult = value;
                RaisePropertyChanged("EntradasResult", null, value, true);
            }
        }

        private FindEntradaResultModel _entradaSel = null;
        public FindEntradaResultModel EntradaSel
        {
            get
            {
                return _entradaSel;
            }
            set
            {
                _entradaSel = value;
                RaisePropertyChanged("EntradaSel", null, value, true);
            }
        }

        #endregion

        #region Commands

        private RelayCommand _loadedCommand;
        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand ?? (_loadedCommand = new RelayCommand(ExecuteLoadedCommand));
            }
        }
        private void ExecuteLoadedCommand()
        {
            try
            {
                EditIsEnabled = true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private RelayCommand _goBackCommand;
        public RelayCommand GoBackCommand
        {
            get
            {
                return _goBackCommand ?? (_goBackCommand = new RelayCommand(ExecuteGoBackCommand));
            }
        }
        private void ExecuteGoBackCommand()
        {
            _navigationService.GoBack();
        }

        private RelayCommand _compraCommand;
        public RelayCommand CompraCommand
        {
            get
            {
                return _compraCommand ?? (_compraCommand = new RelayCommand(ExecuteCompraCommandAsync));
            }
        }
        private async void ExecuteCompraCommandAsync()
        {
            var dialog = new MessageDialog("Buena visión !!!");
            await dialog.ShowAsync();
        }

        #endregion
    }
}
