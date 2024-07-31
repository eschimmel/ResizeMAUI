using ResizeMAUI.ViewModels;

namespace ResizeMAUI.Application.Maui.Controls
{
    public partial class Keyboard : ContentView
    {
        public Keyboard()
        {
            InitializeComponent();
        }

        public Keyboard(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}