using CommunityToolkit.Mvvm.ComponentModel;
using ResizeMAUI.Models;
using ResizeMAUI.Models.Constants;
using ResizeMAUI.Models.Factories;
using ResizeMAUI.ObservableModels;

namespace ResizeMAUI.ViewModels
{
    [ObservableObject]
    public partial class MainViewModel : ViewModelBase
    {
        private readonly IPageLayoutFactory _pageLayoutFactory;

        public byte Idiom { get; set; }

        [ObservableProperty]
        public ObservablePageLayout _pageLayout = new();

        private Member _member = new();
        private List<PageLayout> _pageLayouts = new();

        public MainViewModel()
            : base()
        {
        }

        public MainViewModel(IPageLayoutFactory pageLayoutFactory)
            :base()
        {
            _pageLayoutFactory = pageLayoutFactory;
        }

        public void Initialize(bool isFirstLaunchEver, byte idiom)
        {
            Idiom = idiom;
            _member = GetMember();
        }

        private static Member GetMember()
        {
            // Retrieve member from database
            Member member = new();
            member.PageLayoutType = PageLayoutType.Minimal;

            return member;
        }

        public void CreatePageLayouts(double width, double height, Thickness safeArea)
        {
            _pageLayouts = _pageLayoutFactory.CreatePageLayouts(width, height, Idiom, safeArea);

            // Setting the PageLayout will raise a NotifyPropertyChanged, which will redraw the screen using the new page layout
            PageLayout = SelectPageLayout();
        }

        private ObservablePageLayout SelectPageLayout()
        {
            // Return the layout the user selected
            PageLayout pageLayout = _pageLayouts.FirstOrDefault(i => i.PageLayoutType == _member.PageLayoutType);
            if (pageLayout == null)
            {
                // Return the prefered layout, this is the one with the largest Multiplier value
                pageLayout = _pageLayouts.FirstOrDefault(i => i.IsPreferred) ?? new PageLayout();
            }

            return pageLayout.ToObservablePageLayout();
        }
    }
}
