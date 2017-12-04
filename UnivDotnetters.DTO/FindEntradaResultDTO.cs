using System;
using UnivDotnetters.DTO.Base;

namespace UnivDotnetters.DTO
{
    public class FindEntradaResultDTO : BaseDTO
    {
        private int _sessionsId;
        public int SessionsId
        {
            get
            {
                return _sessionsId;
            }
            set
            {
                _sessionsId = value;
                NotifyPropertyChanged("SessionsId");
            }
        }

        private int _filmId;
        public int FilmId
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

        private DateTime _start;
        public DateTime Start
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

        private bool _isPublished;
        public bool IsPublished
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

        private int _screensId;
        public int ScreensId
        {
            get
            {
                return _screensId;
            }
            set
            {
                _screensId = value;
                NotifyPropertyChanged("ScreensId");
            }
        }

        private string _screenName;
        public string ScreenName
        {
            get
            {
                return _screenName;
            }
            set
            {
                _screenName = value;
                NotifyPropertyChanged("ScreenName");
            }
        }

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

        private int _numberOfFreeSeats;
        public int NumberOfFreeSeats
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

    }
}
