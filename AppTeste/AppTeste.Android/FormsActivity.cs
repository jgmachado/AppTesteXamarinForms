using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Droid.Views;

namespace AppTeste.Droid
{
    [Activity(Label = "AppTeste.Droid", Icon = "@drawable/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class FormsActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
        }
    }
}

