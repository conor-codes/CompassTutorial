using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace CompassTutorial
{
    public class MyCompass
    {
        public event EventHandler<string> GetCompassValue;
        public MyCompass()
        {
            Start();
            Compass.ReadingChanged += Compass_ReadingChanged;
        }

        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            double value = e.Reading.HeadingMagneticNorth;
            string valueFormated = String.Format("{0} {2} {1}", ValidateValue(value).ToString("0"), CalculateDirection(value), "\u00b0");
            GetCompassValue?.Invoke(this, valueFormated);
        }

        private double ValidateValue(double value)
        {
            if(value < 0)
            {
                value += 360;
            }

            return value;
        }

        public void Start()
        {
            try
            {
                Compass.Start(SensorSpeed.UI);
            }
            catch(FeatureNotSupportedException fnsEx)
            {
                Console.WriteLine(fnsEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private string CalculateDirection(double degree)
        {
            if (degree < 22)
            {
                return "North";
            }
            else if (degree < 67)
            {
                return "North East";
            }
            else if (degree < 112)
            {
                return "East";
            }
            else if (degree < 157)
            {
                return "South East";
            }
            else if (degree < 202)
            {
                return "South";
            }
            else if (degree < 247)
            {
                return "South West";
            }
            else if (degree < 292)
            {
                return "West";
            }
            else if (degree < 337)
            {
                return "North West";
            }
            else
            {
                return "North";
            }
        }
    }
}
