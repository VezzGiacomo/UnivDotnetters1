using System;
using System.Collections.Generic;
using UnivDotnetters.DTO.Base;

namespace UnivDotnetters.DTO
{
    public class FindEntradaFilterDTO : BaseDTO
    {
        private bool? _isPublished;
        public bool? IsPublished
        {
            get
            {
                return _isPublished;
            }
            set
            {
                _isPublished = value;
                NotifyPropertyChanged("IsPublished");
            }
        }

        private int? _numberOfFreeSeats;
        public int? NumberOfFreeSeats
        {
            get
            {
                return _numberOfFreeSeats;
            }
            set
            {
                _numberOfFreeSeats = value;
                NotifyPropertyChanged("NumberOfFreeSeats");
            }
        }

        private int? _filmId;
        public int? FilmId
        {
            get
            {
                return _filmId;
            }
            set
            {
                _filmId = value;
                NotifyPropertyChanged("FilmId");
            }
        }

        private DateTime? _start;
        public DateTime? Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
                NotifyPropertyChanged("Start");
            }
        }

        private DateTime? _end;
        public DateTime? End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
                NotifyPropertyChanged("End");
            }
        }

        private int? _cinemaId;
        public int? CinemaId
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

        private List<string> _sessionsType;
        public List<string> SessionsType
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


    }
}
