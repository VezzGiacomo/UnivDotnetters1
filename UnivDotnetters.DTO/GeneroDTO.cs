using System;
using UnivDotnetters.DTO.Base;

namespace UnivDotnetters.DTO
{
    public class GeneroDTO : BaseDTO
    {
        private int _generoId;
        public int GeneroId
        {
            get
            {
                return _generoId;
            }
            set
            {
                _generoId = value;
                NotifyPropertyChanged("GeneroId");
            }
        }

        private string _nombre;
        public string Nombre
         {
            get
            {
                return _nombre;
            }
            set
            {
                if (_nombre == value)
                {
                    return;
                }
                var oldValue = _nombre;
                _nombre = value;
                NotifyPropertyChanged("Nombre");
            }
        }

        private String _logoName;
        public String LogoName
        {
            get
            {
                return _logoName;
            }
            set
            {
                if (_logoName == value)
                {
                    return;
                }
                var oldValue = _logoName;
                _logoName = value;
                NotifyPropertyChanged("LogoName");
                NotifyPropertyChanged("LogoImg");
            }
        }
    }
}
