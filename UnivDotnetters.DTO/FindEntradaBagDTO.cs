using System.Collections.Generic;
using UnivDotnetters.DTO.Base;

namespace UnivDotnetters.DTO
{
    public class FindEntradaBagDTO : BaseDTO
    {
        private List<CinemaDTO> _cinemas;
        public List<CinemaDTO> Cinemas
        {
            get
            {
                return _cinemas;
            }
            set
            {
                _cinemas = value;
                NotifyPropertyChanged("Cinemas");
            }
        }

        private List<SessionTypeDTO> _sessionsType;
        public List<SessionTypeDTO> SessionsType
        {
            get
            {
                return _sessionsType;
            }
            set
            {
                _sessionsType = value;
                NotifyPropertyChanged("SessionsType");
            }
        }

        private List<FilmDTO> _sessionFilms;
        public List<FilmDTO> SessionFilms
        {
            get
            {
                return _sessionFilms;
            }
            set
            {
                _sessionFilms = value;
                NotifyPropertyChanged("SessionFilms");
            }
        }

    }
}
