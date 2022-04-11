using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;

namespace FrontEnd_GameLayout.ViewModels
{

        public abstract class BaseViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                VerifyPropertyName(propertyName);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            [Conditional("DEBUG")]
            private void VerifyPropertyName(string propertyName)
            {
                if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                    throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
            }
        }
}
