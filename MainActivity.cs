using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Content.PM;

namespace Radiation
{
    [Activity(Icon = "@drawable/ic_radiation", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public sealed class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        TextView textMessageDefault;
        TextView radiationAmount;
        TextView description;
        TextView todayRadiation;
        TextView radiationLevels;
        ImageView background;

        private static string fontName = "CodeSaver-Regular.otf";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var font = Typeface.CreateFromAsset(Assets, fontName);
            textMessageDefault = FindViewById<TextView>(Resource.Id.message);
            radiationAmount = FindViewById<TextView>(Resource.Id.radiationAmount);
            todayRadiation = FindViewById<TextView>(Resource.Id.todayRadiation);
            radiationLevels = FindViewById<TextView>(Resource.Id.radiationLevels);
            description = FindViewById<TextView>(Resource.Id.description);
            background = FindViewById<ImageView>(Resource.Id.ImageBack);

            ImageChanger.SetRandomImage(background, this);

            Locale.CurrentLocale = Resources.Configuration.Locale.ToString();
            string[] lang = Locale.MainLocale;

            description.Text = lang[(int)LocaleControls.Description];
            radiationLevels.Text = lang[(int)LocaleControls.RadiationLevels];
            todayRadiation.Text = lang[(int)LocaleControls.RadiationName];

            description.Visibility = ViewStates.Invisible;
            textMessageDefault.Typeface = font;
            radiationAmount.Typeface = font;
            todayRadiation.Typeface = font;
            radiationLevels.Typeface = font;
            description.Typeface = font;

            RadiationData.GetRadiationData(radiationAmount, this);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    OnNavigationHideSelected(false);
                    return true;
                case Resource.Id.navigation_notifications:
                    OnNavigationHideSelected(true);
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Method, that sets visibility of various controls.
        /// </summary>
        /// <param name="mode">Bool that either hides or shows controls.</param>
        private void OnNavigationHideSelected(bool mode)
        {
            radiationAmount.Visibility = mode == true ?
                ViewStates.Invisible : ViewStates.Visible;

            todayRadiation.Visibility = mode == true ?
                ViewStates.Invisible : ViewStates.Visible;

            radiationLevels.Visibility = mode == true ?
                ViewStates.Invisible : ViewStates.Visible;

            description.Visibility = mode == true ?
                ViewStates.Visible : ViewStates.Invisible;
        }

    }
}