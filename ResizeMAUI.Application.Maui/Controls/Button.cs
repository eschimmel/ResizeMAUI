using ResizeMAUI.ObservableModels;

namespace ResizeMAUI.Application.Maui.Controls
{
    public class Button : Microsoft.Maui.Controls.Button
    {
        public static readonly BindableProperty PageLayoutProperty =
            BindableProperty.Create(nameof(PageLayout), typeof(ObservablePageLayout), typeof(Button), new ObservablePageLayout(), propertyChanged: OnPageLayoutChanged);

        public static void OnPageLayoutChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is Button button)
            {
                if (newValue is ObservablePageLayout pageLayout)
                {
                    button.MinimumWidthRequest = pageLayout.ButtonWidth;
                    button.MinimumHeightRequest = pageLayout.ButtonHeight;
                    button.Padding = new Thickness(pageLayout.ButtonPaddingHorizontal, pageLayout.ButtonPaddingVertical);
                    button.FontSize = pageLayout.FontSize;
                    button.CornerRadius = pageLayout.ButtonCornerRadius;
                }
            }
        }

        public ObservablePageLayout PageLayout
        {
            get => (ObservablePageLayout)GetValue(PageLayoutProperty);
            set => SetValue(PageLayoutProperty, value);
        }
    }
}
