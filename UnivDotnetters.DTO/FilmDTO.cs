using UnivDotnetters.DTO.Base;

namespace UnivDotnetters.DTO
{
    public class FilmDTO : BaseDTO
    {
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id == value)
                {
                    return;
                }
                var oldValue = _id;
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title == value)
                {
                    return;
                }
                var oldValue = _title;
                _title = value;
                NotifyPropertyChanged("Title");
            }
        }

        private int _durationInMinutes;
        public int DurationInMinutes
        {
            get
            {
                return _durationInMinutes;
            }
            set
            {
                if (_durationInMinutes == value)
                {
                    return;
                }
                var oldValue = _durationInMinutes;
                _durationInMinutes = value;
                NotifyPropertyChanged("DurationInMinutes");
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
