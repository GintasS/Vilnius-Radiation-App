using Android.App;
using Android.Widget;
using System.Drawing;

namespace Radiation
{
    static class Alert
    {
        /// <summary>
        /// Method, that displays an error to the user.
        /// </summary>
        /// <param name="msg">Error message to display.</param>
        /// <param name="ac">MainActivity to display to.</param>
        public static void ShowErrorAlert(string msg, MainActivity ac)
        {
            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(ac);
            alert.SetTitle(Locale.AlertTitle);
            alert.SetMessage(msg);
            alert.SetCancelable(false);
            alert.SetPositiveButton("OK", (senderAlert, args) => { });
                     
            Dialog dialog = alert.Create();
            
            dialog.Show();
        }
    }
}