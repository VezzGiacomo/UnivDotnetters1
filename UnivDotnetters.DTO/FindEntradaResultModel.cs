namespace UnivDotnetters.DTO
{
    public class FindEntradaResultModel : FindEntradaResultDTO
    {
        private string _filmName;
        public string FilmName
        {
            get
            {
                return _filmName;
            }
            set
            {
                _filmName = value;
                NotifyPropertyChanged("FilmName");
            }
        }

        private string _cinemaName;
        public string CinemaName
        {
            get
            {
                return _cinemaName;
            }
            set
            {
                _cinemaName = value;
                NotifyPropertyChanged("CinemaName");
            }
        }

    }
}
