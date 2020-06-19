using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Theme
{
    public class ViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        private double _vscale = 1;
        public double VScale
        {
            get
            {
                return _vscale;
            }
            set
            {
                _vscale = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("VScale");
            }
        }


        #region INotifyPropertyChanged

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPropertyChanged
    }
}
