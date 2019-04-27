using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace Radiation
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/ic_radiation", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        TextView textMessageDefault;
        TextView radiationAmount;
        TextView description;
        TextView todayRadiation;
        TextView radiationLevels;

        string desc = "This is an unofficial app of Vilnius radiation.The app and the Facebook group are " +
            "run by enthusiasts, so take the data with a pinch of salt." + "\n" +
            "App & Facebook group are not in any way " +
            "related to authorities of Radiation Protection Centre(RPC), Environmental Protection Agency(EPA) " +
            "or any other agency/organization. " + "\n" +
            "You can find Facebook group, where radiation data is being posted daily, here: " + "\n" +
            "facebook.com/VilniausRadiacinisFonas/ or simply - Vilniaus Radiacinis Fonas.";

        string levels = "Radiation levels:" + "\n" +
                        "N/A - Data is not available." + "\n" +
                        "0 - 0.1 µSv/h - Very low radiation." + "\n" +
                        "0.1 - 0.2 µSv/h - Low radiation." + "\n" +
                        "0.2 - 0.3 µSv/h - Medium radiation." + "\n" +
                        "0.3 - 0.5 µSv/h - Increased radiation." + "\n" +
                        "0.5 µSv/h & more - High radiation.";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var font = Typeface.CreateFromAsset(Assets, "AireExterior.ttf");
            textMessageDefault = FindViewById<TextView>(Resource.Id.message);
            radiationAmount = FindViewById<TextView>(Resource.Id.radiationAmount);
            todayRadiation = FindViewById<TextView>(Resource.Id.todayRadiation);
            radiationLevels = FindViewById<TextView>(Resource.Id.radiationLevels);
            description = FindViewById<TextView>(Resource.Id.description);

            description.Visibility = ViewStates.Invisible;

            textMessageDefault.Typeface = font;
            radiationAmount.Typeface = font;
            todayRadiation.Typeface = font;
            radiationLevels.Typeface = font;
            description.Typeface = font;

            radiationLevels.Text = levels;

            RadiationData.GetRadiationData(radiationAmount, 1);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    description.Text = RadiationData.RadiationLabel;
                    OnNavigationHideSelected(false);
                    return true;
                case Resource.Id.navigation_notifications:
                    description.Text = desc;
                    OnNavigationHideSelected(true);
                    return true;
            }
            return false;
        }

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