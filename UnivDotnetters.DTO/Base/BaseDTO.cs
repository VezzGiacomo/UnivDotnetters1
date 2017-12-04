using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UnivDotnetters.DTO.Base
{
    public class BaseDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
