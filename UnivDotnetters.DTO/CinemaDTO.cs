using UnivDotnetters.DTO.Base;

namespace UnivDotnetters.DTO
{
    public class CinemaDTO : BaseDTO
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

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == value)
                {
                    return;
                }
                var oldValue = _name;
                _name = value;
                NotifyPropertyChanged("Name");
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
