using ResizeMAUI.Models.Constants;

namespace ResizeMAUI.Models.Factories
{
    public class PageLayoutFactory : IPageLayoutFactory
    {
        private double _width;
        private double _height;
        private Thickness _safeArea;

        public List<PageLayout> CreatePageLayouts(double width, double height, byte idiom, Thickness safeArea)
        {
            _width = width;
            _height = height;
            _safeArea = safeArea;

            // Always choose the largest side as the width, because we only allow Landscape orientation on Phone and Tablet
            if (idiom == Idiom.Phone || idiom == Idiom.Tablet)
            {
                _width = Math.Max(width, height);
                _height = Math.Min(width, height);
            }

            PageLayout minimalPageLayout = CreateMinimalPageLayout();

            List<PageLayout> pageLayouts = new();
            pageLayouts.Add(minimalPageLayout);

            minimalPageLayout.IsPreferred = true;
            return pageLayouts;
        }

        // This layout 3 rows of alpha numric keys
        // On the far right there is a column of control buttons, e.g. Show All
        public PageLayout CreateMinimalPageLayout()
        {
            // Setting the SafeArea is important, because it used to calculate the Padding
            PageLayout layout = new()
            {
                PageLayoutType = PageLayoutType.Minimal,
                SafeArea = _safeArea
            };

            // Calculate the required minimal dimensions
            // Width = Padding Left | Button 1 | InnerSpacing | Button 2 | InnerSpacing | ... | Button 10 | OuterSpacing | Right Column Width | Padding Right
            // Height = Padding Top | Row Height | InnerSpacing | Button Height for Suggestions | InnerSpacing | Key Row 1 | InnerSpacing | ... | Key Row 4 | Padding Bottom
            layout.Width = layout.Padding.Left + (10 * layout.ButtonWidth) + (9 * layout.InnerSpacing) + layout.OuterSpacing + layout.RightColumnWidth + layout.Padding.Right;
            layout.Height = layout.Padding.Top + (5 * layout.ButtonHeight) + layout.RowHeight + (5 * layout.InnerSpacing) + layout.Padding.Bottom;

            // Calcute the multipliers by dividing the actual size with the minimal size
            double horizontalMultiplier = _width / layout.Width;
            double verticalMultiplier = _height / layout.Height;

            // Choose the smallest multiplier to ensure that all the layout elements will fit
            double multiplier = Math.Min(horizontalMultiplier, verticalMultiplier);

            layout.Multiplier = multiplier;
            layout.IsValid = (multiplier >= 1.0);

            return layout;
        }
    }
}
