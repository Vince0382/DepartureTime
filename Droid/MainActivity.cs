using Android.App;
using Android.Content.PM;
using Android.OS;
using CarouselView.FormsPlugin.Android;
using Plugin.CrossPlatformTintedImage.Android;

namespace DepartureTime.Droid
{
    [Activity(Label = "DepartureTime.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
			TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
       
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			CarouselViewRenderer.Init();   
			TintedImageRenderer.Init();

            LoadApplication(new App());
        }
    }
}
