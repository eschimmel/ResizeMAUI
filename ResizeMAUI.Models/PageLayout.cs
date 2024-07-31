namespace ResizeMAUI.Models
{
    public class PageLayout
    {
        public Thickness Padding { get; set; } = new Thickness(10, 10, 10, 10);

        public double OuterSpacing { get; set; } = 10;
        public double InnerSpacing { get; set; } = 5;
        public double RowHeight { get; set; } = 44;

        public double ButtonWidth { get; set; } = 44;
        public double ButtonHeight { get; set; } = 44;
        public double SpaceButtonWidth { get; set; } = 142;
        public double ButtonPaddingHorizontal { get; set; } = 12;
        public double ButtonPaddingVertical { get; set; } = 8;
        public int ButtonCornerRadius { get; set; } = 8;

        public double RightColumnWidth { get; set; } = 100;
        public double BottomRowHeight { get; set; }

        public int FontSize { get; set; } = 16;
        public int LabelFontSize { get; set; } = 14;
        public int TextDisplayFontSize { get; set; } = 20;
        public double TextDisplayEntryHeight { get; set; } = 42;

        public double Width { get; set; }
        public double Height { get; set; }
        public double Multiplier { get; set; } = 1;
        public bool IsValid { get; set; } = false;

        public byte PageLayoutType { get; set; } = Constants.PageLayoutType.Minimal;
        public bool IsPreferred { get; set; } = false;

        public string ButtonMargin
        {
            get
            {
                int value = (int)Math.Floor(InnerSpacing * Multiplier);
                return $"{value},0,0,{value}";
            }
        }

        public string LabelMargin
        {
            get
            {
                int value = (int)Math.Floor(InnerSpacing * Multiplier) * 3;
                return $"{value},0,0,0";
            }
        }

        public Thickness SafeArea
        {
            set
            {
                Padding.Left = Math.Max(OuterSpacing, value.Left);
                Padding.Top = Math.Max(OuterSpacing, value.Top);
                Padding.Right = Math.Max(OuterSpacing, value.Right);
                Padding.Bottom = Math.Max(OuterSpacing, value.Bottom);
            }
        }

        public string PagePadding
        {
            get
            {
                int left = (int)Math.Floor(Padding.Left * Multiplier);
                int top = (int)Math.Floor(Padding.Top * Multiplier);
                int right = (int)Math.Floor(Padding.Right * Multiplier);
                int bottom = (int)Math.Floor(Padding.Bottom * Multiplier);

                return $"{left},{top},{right},{bottom}";
            }
        }
    }
}
