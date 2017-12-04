using UnivDotnetters.DTO.Base;

namespace UnivDotnetters.DTO
{
    public class SessionTypeDTO : BaseDTO
    {
        private int _cinemaId;
        public int CinemaId
        {
            get
            {
                return _cinemaId;
            }
            set
            {
                _cinemaId = value;
                NotifyPropertyChanged("CinemaId");
            }
        }

        private string _sessionType;
        public string SessionType // "M" = Mañana, "T" = Tarde, "N" = Noche
        {
            get
            {
                return _sessionType;
            }
            set
            {
                _sessionType = value;
                NotifyPropertyChanged("SessionType");
                NotifyPropertyChanged("SessionTypeDescription");
            }
        }

        public string SessionTypeDescription
        {
            get
            {
                switch ((SessionType ?? string.Empty))
                {
                    case "M":
                        return "Mañana";
                    case "T":
                        return "Tarde";
                    case "N":
                        return "Noche";
                    default:
                        return string.Empty;
                }
            }
        }

        private bool _isSelectedItem;
        public bool IsSelectedItem
        {
            get
            {
                return _isSelectedItem;
            }
            set
            {
                if (_isSelectedItem == value)
                {
                    return;
                }
                var oldValue = _isSelectedItem;
                _isSelectedItem = value;
                NotifyPropertyChanged("IsSelectedItem");
            }
        }

    }
}
