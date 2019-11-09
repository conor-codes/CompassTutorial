using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CompassTutorial
{
    class CompassViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string compassValue;

        public string CompassValue
        {
            set
            {
                if(compassValue != value)
                {
                    compassValue = value;
                    OnPropertyChanged("CompassValue");
                }
            }
            get
            {
                return compassValue;
            }
        }

        public void StartCompass()
        {
            var myCompass = new MyCompass();
            myCompass.GetCompassValue += MyCompass_GetCompassValue;
        }

        private void MyCompass_GetCompassValue(object sender, string e)
        {
            CompassValue = e;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if(changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
