using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using UnivDotnetters.DTO;
using UnivDotnetters.IServices;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

namespace UnivDotnetters.ViewModel
{
    public class CinematicMainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IFindEntradaBagSrv _findEntradaBagSrv;
        private readonly IFindEntradaSrv _findEntradaSrv;

        public CinematicMainViewModel(INavigationService navigationService
                                      ,IFindEntradaBagSrv findEntradaBagSrv
                                      ,IFindEntradaSrv findEntradaSrv)
        {
            try
            {
                #region Servicios

                _navigationService = navigationService;
                _findEntradaBagSrv = findEntradaBagSrv;
                _findEntradaSrv = findEntradaSrv;

                #endregion

                #region Default property values

                _titlePage = "Cinematic Encuentra tu peli con DotNetters";

                _sessionTypes = new ObservableCollection<SessionTypeDTO>(new List<SessionTypeDTO> {
                    new SessionTypeDTO { CinemaId = 0, SessionType = "M" }
                    ,new SessionTypeDTO { CinemaId = 0, SessionType = "T" }
                    ,new SessionTypeDTO { CinemaId = 0, SessionType = "N" }
                });
                foreach (SessionTypeDTO stipo in SessionTypes)
                {
                    stipo.PropertyChanged += OnSessionTypePropertyChanged;
                }
                SessionTypes.CollectionChanged += OnSessionTypesCollectionChanged;

                _generos = new ObservableCollection<GeneroDTO>(new List<GeneroDTO> {
                    new GeneroDTO { GeneroId = 1, Nombre = "Drama", LogoName = "ms-appx://UnivDotnetters/Assets/Drama.PNG" }
                    ,new GeneroDTO { GeneroId = 2, Nombre = "Comedia", LogoName = "ms-appx://UnivDotnetters/Assets/Comedia.png" }
                    ,new GeneroDTO { GeneroId = 3, Nombre = "Acción", LogoName = "ms-appx://UnivDotnetters/Assets/Accion.png" }
                    ,new GeneroDTO { GeneroId = 4, Nombre = "Ciencia ficción", LogoName = "ms-appx://UnivDotnetters/Assets/CienciaFiccion.png" }
                    ,new GeneroDTO { GeneroId = 5, Nombre = "Suspense", LogoName = "ms-appx://UnivDotnetters/Assets/Suspense.png" }
                });
                _fechaStart = DateTime.Now.Date;
      
                //
                // Solo en modo disegno
                //
                if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                // Windows.ApplicationModel.DesignMode.DesignMode2Enabled (solo por Fall Creators Update)
                {
                    InitDebugPageValues();
                }
                #endregion

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
            _titlePage = String.Format("{0} DESIGN", _titlePage);

            _cinemas = new ObservableCollection<CinemaDTO>(new List<CinemaDTO> {
                    new CinemaDTO { Id = 1, Name = "Palafox DESIGN" }
                    ,new CinemaDTO { Id = 2, Name = "Cervantes DESIGN" }
            });

            _peliculas = new ObservableCollection<FilmDTO>(new List<FilmDTO> {
                    new FilmDTO { Id = 1, Title = "Liga de la Justicia DESIGN", DurationInMinutes = 120, IsSelectedItem = true }
                    ,new FilmDTO { Id = 2, Title = "El secreto de Marrowbone DESIGN", DurationInMinutes = 90 }
                    ,new FilmDTO { Id = 3, Title = "Oro DESIGN", DurationInMinutes = 110, IsSelectedItem = true }
                    ,new FilmDTO { Id = 4, Title = "Thor: Ragnarok DESIGN", DurationInMinutes = 100 }
                    ,new FilmDTO { Id = 5, Title = "Toc Toc DESIGN", DurationInMinutes = 95 }
            });

            _genero = new GeneroDTO { GeneroId = 2, Nombre = "Comedia", LogoName = "ms-appx://UnivDotnetters/Assets/Comedia.png" };
        }

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

        private ObservableCollection<SessionTypeDTO> _sessionTypes = null;
        public ObservableCollection<SessionTypeDTO> SessionTypes
        {
            get
            {
                return _sessionTypes;
            }
            set
            {
                _sessionTypes = value;
                RaisePropertyChanged("SessionTypes", null, value, true);
            }
        }

        private ObservableCollection<GeneroDTO> _generos = null;
        public ObservableCollection<GeneroDTO> Generos
        {
            get
            {
                return _generos;
            }
            set
            {
                _generos = value;
                RaisePropertyChanged("Generos", null, value, true);
            }
        }

        private GeneroDTO _genero = null;
        public GeneroDTO Genero
        {
            get
            {
                return _genero;
            }
            set
            {
                _genero = value;
                RaisePropertyChanged("Genero", null, value, true);
                RaisePropertyChanged("LogoImage");
            }
        }

        public BitmapImage LogoImage
        {
            get
            {
                if (Genero != null && !String.IsNullOrWhiteSpace(Genero.LogoName))
                {
                    Uri uri = new Uri(Genero.LogoName);
                    BitmapImage _logoImage = new BitmapImage(uri);
                    return _logoImage;
                }
                else
                {
                    return null;
                }
            }
        }

        private DateTimeOffset? _fechaStart = null;
        public DateTimeOffset? FechaStart
        {
            get
            {
                return _fechaStart;
            }
            set
            {
                _fechaStart = value;
                RaisePropertyChanged("FechaStart", null, value, true);
            }
        }

        private int _numeroDePersonas = 1;
        public int NumeroDePersonas
        {
            get
            {
                return _numeroDePersonas;
            }
            set
            {
                _numeroDePersonas = value;
                RaisePropertyChanged("NumeroDePersonas");
            }
        }

        private ObservableCollection<CinemaDTO> _cinemas = null;
        public ObservableCollection<CinemaDTO> Cinemas
        {
            get
            {
                return _cinemas;
            }
            set
            {
                _cinemas = value;
                RaisePropertyChanged( "Cinemas", null, value, true);
            }
        }

        private ObservableCollection<FilmDTO> _peliculas = null;
        public ObservableCollection<FilmDTO> Peliculas
        {
            get
            {
                return _peliculas;
            }
            set
            {
                _peliculas = value;
                RaisePropertyChanged("Peliculas", null, value, true);
            }
        }

        private List<SessionTypeDTO> CinemasPorSessionTypes = new List<SessionTypeDTO>();

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
        private async void ExecuteLoadedCommand()
        {
            try
            {
                FindEntradaBagDTO bag = await _findEntradaBagSrv.GetSessionsBag(DateTime.Now, null);
                if (bag != null)
                {
                    if (bag.Cinemas != null)
                        Cinemas = new ObservableCollection<CinemaDTO>(bag.Cinemas);
                    if (bag.SessionFilms != null)
                        Peliculas = new ObservableCollection<FilmDTO>(bag.SessionFilms);
                    if (bag.SessionsType != null)
                        CinemasPorSessionTypes = bag.SessionsType;
                }
                FechaStart = DateTime.Now.Date;
                EditIsEnabled = true;
            }
            catch (Exception ex)
            {
                throw (ex);
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
            return true;
        }

        private RelayCommand _findPeliCommand;
        public RelayCommand FindPeliCommand
        {
            get
            {
                return _findPeliCommand ?? (_findPeliCommand = new RelayCommand(
                                            ExecuteFindPeliCommandAsync,
                                            CanExecuteFindPeliCommand));
            }
        }

        private async void ExecuteFindPeliCommandAsync()
        {
            try
            {
                EditIsEnabled = false;

                FindEntradaFilterDTO filters = new FindEntradaFilterDTO
                {
                    NumberOfFreeSeats = NumeroDePersonas,
                    FilmId = (Peliculas.FirstOrDefault(p => p.IsSelectedItem) ?? new FilmDTO()).Id,
                    Start = (FechaStart ?? DateTimeOffset.Now).DateTime,
                    CinemaId = (Cinemas.FirstOrDefault(p => p.IsSelectedItem) ?? new CinemaDTO()).Id,
                    SessionsType = SessionTypes.Where(p => p.IsSelectedItem).Select(f => f.SessionType).ToList()
                };
                List<FindEntradaResultDTO> entradas = await _findEntradaSrv.FindEntradas((filters.Start ?? DateTime.Now)
                                    , filters.SessionsType.ToArray(), filters.CinemaId, filters.FilmId);
                if (entradas != null && entradas.Any())
                {
                    List<FindEntradaResultModel> entradasModel = new List<FindEntradaResultModel>();
                    var query =
                       from entrada in entradas
                       join cine in Cinemas on entrada.CinemaId equals cine.Id
                       join peli in Peliculas on entrada.FilmId equals peli.Id
                       select new { Entrada = entrada, Cine = cine, Peli = peli };
                    foreach (var ele in query)
                    {
                        entradasModel.Add(new FindEntradaResultModel
                        {
                            SessionsId = ele.Entrada.SessionsId,
                            FilmId = ele.Entrada.FilmId,
                            Start = ele.Entrada.Start,
                            IsPublished = ele.Entrada.IsPublished,
                            ScreensId = ele.Entrada.ScreensId,
                            ScreenName = ele.Entrada.ScreenName,
                            CinemaId = ele.Entrada.CinemaId,
                            NumberOfFreeSeats = ele.Entrada.NumberOfFreeSeats,
                            FilmName = (ele.Peli ?? new FilmDTO()).Title,
                            CinemaName = (ele.Cine ?? new CinemaDTO()).Name
                        });
                    }

                    _navigationService.NavigateTo("CinematicResultPage", filters);

                    Messenger.Default.Send(entradasModel);
                }
                else
                {
                    var dialog = new MessageDialog("Lo sentimos, no hay entradas disponibles.");
                    await dialog.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                EditIsEnabled = true;
            }
        }
        private bool CanExecuteFindPeliCommand()
        {
            try
            {
                bool ret = false;
                ret = (ret || (Peliculas != null && Peliculas.Any(p => p.IsSelectedItem)));
                ret = (ret || (Cinemas != null && Cinemas.Any(p => p.IsSelectedItem)));
                ret = (ret || (SessionTypes != null && SessionTypes.Any(p => p.IsSelectedItem)));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void OnSessionTypesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.NewItems != null)
                {
                    foreach (SessionTypeDTO newItem in e.NewItems)
                    {
                        newItem.PropertyChanged += OnSessionTypePropertyChanged;
                    }
                }
                if (e.OldItems != null)
                {
                    foreach (SessionTypeDTO oldItem in e.OldItems)
                    {
                        oldItem.PropertyChanged -= OnSessionTypePropertyChanged;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OnSessionTypePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                List<String> SelSesiones = SessionTypes.Where(s => s.IsSelectedItem).Select(z => z.SessionType).ToList();
                List<int> IdsCinesAbiertos = CinemasPorSessionTypes.Where(s => SelSesiones.Contains(s.SessionType)).Select(z => z.CinemaId).Distinct().ToList();
                Cinemas.ToList().ForEach(c => c.IsSelectedItem = (IdsCinesAbiertos.Contains(c.Id)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
