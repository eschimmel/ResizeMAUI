using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using ResizeMAUI.ViewModels;

namespace ResizeMAUI.Application.Maui.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnBindingContextChanged()
        {
            InitializeViewModel();
            base.OnBindingContextChanged();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            // width and height are the dimensions of the drawable area.
            // This excludes all the stattus bars, navigation bars etc.

            AppShell appShell = Microsoft.Maui.Controls.Application.Current.MainPage as AppShell;
            if (appShell.CurrentPage == this)
            { 
                if (BindingContext is MainViewModel viewModel)
                {
                    // iOS has reserved a safeArea on the borders of the screen.
                    // This must be taken into account when calculating the page layouts

                    Thickness safeArea = On<iOS>().SafeAreaInsets();
                    viewModel.CreatePageLayouts(width, height, new Models.Thickness(safeArea.Left, safeArea.Top, safeArea.Right, safeArea.Bottom));
                }

                base.OnSizeAllocated(width, height);
            }
        }

        private void InitializeViewModel()
        {
            byte idiom = GetIdiom();

            MainViewModel viewModel = BindingContext as MainViewModel;
            viewModel.Initialize(VersionTracking.Default.IsFirstLaunchEver, idiom);
        }

        private static byte GetIdiom()
        {
            byte idiom = Models.Constants.Idiom.Unknown;

            DeviceIdiom deviceIdiom = DeviceInfo.Current.Idiom;
            if (deviceIdiom == DeviceIdiom.Phone)
            {
                idiom = Models.Constants.Idiom.Phone;
            }

            if (deviceIdiom == DeviceIdiom.Tablet)
            {
                idiom = Models.Constants.Idiom.Tablet;
            }

            if (deviceIdiom == DeviceIdiom.Desktop)
            {
                idiom |= Models.Constants.Idiom.Desktop;
            }

            return idiom;
        }
    }
}
