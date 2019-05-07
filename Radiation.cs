using System;
using Android.Widget;
using System.Net;
using System.IO;
using System.Globalization;

namespace Radiation
{
    static class RadiationData
    {
        // Fields, that are needed for API access.
        private static string dateFormat = "yyyy-MM-dd";
        private static string APIBaseUrl = @"http://vilniausfonas.info/en/radiation/radiationapi.php?date=";

        // Fields, that are responsible with data being printed on the screen.
        private static string radiationUnit = "µSv/h";
        private static string dataNotAvailable = "N/A";

        /// <summary>
        /// Method, that gets radiation data from API.
        /// </summary>
        /// <param name="view">TextView model to display to.</param>
        public static void GetRadiationData(TextView view, MainActivity ac)
        {
            string html = string.Empty,
                   today = DateTime.Today.ToString(dateFormat),
                   url = APIBaseUrl + today;

            string[] exceptionData = Locale.ExceptionLocale;
            int internet = (int)LocaleExceptControls.Internet;
            int general = (int)LocaleExceptControls.General;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
            }
            catch(WebException ex)
            {
                if (ex.Message == "Error: NameResolutionFailure")
                    Alert.ShowErrorAlert(exceptionData[internet], ac);
                else
                    Alert.ShowErrorAlert(exceptionData[general], ac);

                view.Text = dataNotAvailable;
                return;
            }
            catch(Exception ex)
            {
                Alert.ShowErrorAlert(exceptionData[general] + ex.Message, ac);

                view.Text = dataNotAvailable;
                return;
            }

            bool isNumber = Double.TryParse(html, NumberStyles.AllowDecimalPoint, 
                CultureInfo.InvariantCulture, out double number);

            if (isNumber)
                view.Text = number.ToString().Replace(",", ".") + " " + radiationUnit;
            else
                view.Text = dataNotAvailable;
        }
    }
}