using System;
using Android.Widget;
using System.Net;
using System.IO;

namespace Radiation
{
    static class RadiationData
    {
        public static string RadiationLabel = "Today's radiation:";
        private static string DateFormat = "yyyy-MM-dd";
        private static string APIBaseUrl = @"http://vilniausfonas.info/en/radiation/radiationapi.php?date=";

        /// <summary>
        /// Method, that gets radiation data from API.
        /// </summary>
        /// <param name="view">TextView model to display to.</param>
        /// <param name="mode">Determines date.1 - today's, 2 - yesterday's.</param>
        public static void GetRadiationData(TextView view, int mode)
        {
            string html = string.Empty,
                   yesterday = DateTime.Today.AddDays(-1).ToString(DateFormat),
                   today = DateTime.Today.ToString(DateFormat),
                   url = "-";

            if (mode == 1)
                url = APIBaseUrl + today;
            else if (mode == 2)
                url = APIBaseUrl + yesterday;

            Console.WriteLine(url);

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
            catch
            {
                view.Text = "-";
                return;
            }

            double amount;
            bool isNumeric = double.TryParse(html, out amount);

            if (isNumeric)
                view.Text = amount + " µSv/h";
            else
                view.Text = "-";
        }
    }
}