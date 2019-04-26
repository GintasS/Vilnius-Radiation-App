using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Radiation
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        TextView textMessageDefault;
        TextView todayRadiation;
        TextView yesterdayRadiation;
        TextView yesterdayText;
        TextView todayText;
        TextView radiationLevels;

        string desc = "This is an unofficial app of Vilnius radiation.The app and the Facebook group are " +
            "run by enthusiasts, so take the data with a pinch of salt." + "\n" +
            "App & Facebook group are not in any way " +
            "related to authorities of Radiation Protection Centre(RPC), Environmental Protection Agency(EPA) " +
            "or any other agency/organization. " + "\n" +
            "You can find Facebook group, where radiation data is being posted daily, here: " + "\n" +
            "facebook.com/VilniausRadiacinisFonas/ or simply - Vilniaus Radiacinis Fonas.";

        string levels = "Radiation levels:" + "\n" +
                        "0 - 0.1 µSv/h - Very low radiation." + "\n" +
                        "0.1 - 0.2 µSv/h - Low radiation." + "\n" +
                        "0.2 - 0.3 µSv/h - Medium radiation." + "\n" +
                        "0.3 - 0.5 µSv/h - Increased radiation." + "\n" +
                        "0.5 µSv/h & more - High radiation.";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            textMessageDefault = FindViewById<TextView>(Resource.Id.message);
            todayRadiation = FindViewById<TextView>(Resource.Id.todayRadiation);
            yesterdayRadiation = FindViewById<TextView>(Resource.Id.yestRadiation);
            yesterdayText = FindViewById<TextView>(Resource.Id.textViewYestText);
            todayText = FindViewById<TextView>(Resource.Id.textViewTodayText);
            radiationLevels = FindViewById<TextView>(Resource.Id.radiationLevels);
            radiationLevels.Text = levels;

            RadiationData.GetRadiationData(todayRadiation, 1);
            RadiationData.GetRadiationData(yesterdayRadiation, 2);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    textMessageDefault.SetText(Resource.String.title_home);
                    todayText.Text = RadiationData.RadiationLabel;
                    OnNavigationHideSelected(false);
                    return true;
                case Resource.Id.navigation_notifications:
                    todayText.Text = desc;
                    textMessageDefault.SetText(Resource.String.title_notifications);
                    OnNavigationHideSelected(true);
                    return true;
            }
            return false;
        }

        private void OnNavigationHideSelected(bool mode)
        {
            todayRadiation.Visibility = mode == true ?
                ViewStates.Invisible : ViewStates.Visible;

            yesterdayRadiation.Visibility = mode == true ?
                ViewStates.Invisible : ViewStates.Visible;

            yesterdayText.Visibility = mode == true ?
                ViewStates.Invisible : ViewStates.Visible;

            radiationLevels.Visibility = mode == true ?
                ViewStates.Invisible : ViewStates.Visible;
        }
    }
}

