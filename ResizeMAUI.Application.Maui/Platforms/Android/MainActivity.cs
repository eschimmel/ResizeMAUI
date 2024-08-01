using Android.App;
using Android.Content.PM;

namespace ResizeMAUI.Application.Maui
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,ScreenOrientation = ScreenOrientation.Landscape, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}
