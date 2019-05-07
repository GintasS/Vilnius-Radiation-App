using Android.Widget;
using System;

namespace Radiation
{
    static class ImageChanger
    {
        private static int minImageNumber = 1;
        private static int maxImageNumber = 14;

        /// <summary>
        /// Generates random number for image name.
        /// </summary>
        /// <returns>Image name.</returns>
        private static string GetRandomImageName()
        {
            Random rnd = new Random();
            return "img" + rnd.Next(minImageNumber, maxImageNumber);
        }

        /// <summary>
        /// Sets random image to ImageView control.
        /// </summary>
        /// <param name="view">ImageView to set image to.</param>
        /// <param name="mn">Current Activity</param>
        public static void SetRandomImage(ImageView view, MainActivity mn)
        {
            string imgName = GetRandomImageName();
            Console.WriteLine(imgName);
            int id = mn.Application.Resources.GetIdentifier(imgName, "drawable", mn.PackageName);
            view.SetImageResource(id);
        }
    }
}