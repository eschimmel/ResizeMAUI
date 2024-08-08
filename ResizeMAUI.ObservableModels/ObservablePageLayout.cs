using ResizeMAUI.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ResizeMAUI.ObservableModels
{
    public class ObservablePageLayout : PageLayout, INotifyPropertyChanged
    {
        public new double OuterSpacing
        {
            get
            {
                return (double)Math.Floor(base.OuterSpacing * base.Multiplier);
            }
            set
            {
                base.OuterSpacing = value;
                NotifyPropertChanged();
            }
        }

        public new double InnerSpacing
        {
            get
            {
                return (double)Math.Floor(base.InnerSpacing * base.Multiplier);
            }
            set
            {
                base.InnerSpacing = value;
                NotifyPropertChanged();
            }
        }

        public new double RowHeight
        {
            get
            {
                return (double)Math.Floor(base.RowHeight * base.Multiplier);
            }
            set
            {
                base.RowHeight = value;
                NotifyPropertChanged();
            }
        }

        public new double ButtonWidth
        {
            get
            {
                return (double)Math.Floor(base.ButtonWidth * base.Multiplier);
            }
            set
            {
                base.ButtonWidth = value;
                NotifyPropertChanged();
            }
        }

        public new double ButtonHeight
        {
            get
            {
                return (double)Math.Floor(base.ButtonHeight * base.Multiplier);
            }
            set
            {
                base.ButtonHeight = value;
                NotifyPropertChanged();
            }
        }

        public new double SpaceButtonWidth
        {
            get
            {
                return (double)Math.Floor(base.SpaceButtonWidth * base.Multiplier);
            }
            set
            {
                base.SpaceButtonWidth = value;
                NotifyPropertChanged();
            }
        }

        public new double ButtonPaddingHorizontal
        {
            get
            {
                return (double)Math.Floor(base.ButtonPaddingHorizontal * base.Multiplier);
            }
            set
            {
                base.ButtonPaddingHorizontal = value;
                NotifyPropertChanged();
            }
        }

        public new double ButtonPaddingVertical
        {
            get
            {
                return (double)Math.Floor(base.ButtonPaddingVertical * base.Multiplier);
            }
            set
            {
                base.ButtonPaddingVertical = value;
                NotifyPropertChanged();
            }
        }

        public new int ButtonCornerRadius
        {
            get
            {
                return (int)Math.Floor(base.ButtonCornerRadius * base.Multiplier);
            }
            set
            {
                base.ButtonCornerRadius = value;
                NotifyPropertChanged();
            }
        }

        public new double RightColumnWidth
        {
            get
            {
                return (double)Math.Floor(base.RightColumnWidth * base.Multiplier);
            }
            set
            {
                base.RightColumnWidth = value;
                NotifyPropertChanged();
            }
        }

        public new double BottomRowHeight
        {
            get
            {
                return (double)Math.Floor(base.BottomRowHeight * base.Multiplier);
            }
            set
            {
                base.BottomRowHeight = value;
                NotifyPropertChanged();
            }
        }

        public new double FontSize
        {
            get
            {
                return (double)Math.Floor(base.FontSize * base.Multiplier);
            }
            set
            {
                base.FontSize = value;
                NotifyPropertChanged();
            }
        }

        public new double LabelFontSize
        {
            get
            {
                return (double)Math.Floor(base.LabelFontSize * base.Multiplier);
            }
            set
            {
                base.LabelFontSize = value;
                NotifyPropertChanged();
            }
        }

        public new double TextDisplayFontSize
        {
            get
            {
                return (double)Math.Floor(base.TextDisplayFontSize * base.Multiplier);
            }
            set
            {
                base.TextDisplayFontSize = value;
                NotifyPropertChanged();
            }
        }

        public new double TextDisplayEntryHeight
        {
            get
            {
                return (int)Math.Floor(base.TextDisplayEntryHeight * base.Multiplier);
            }
            set
            {
                base.TextDisplayEntryHeight = value;
                NotifyPropertChanged();
            }
        }

        public new double Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
                NotifyPropertChanged();
            }
        }

        public new double Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
                NotifyPropertChanged();
            }
        }

        public new double Multiplier
        {
            get
            {
                return base.Multiplier;
            }
            set
            {
                base.Multiplier = value;
                NotifyPropertChanged();
            }
        }

        public new bool IsValid
        {
            get
            {
                return base.IsValid;
            }
            set
            {
                base.IsValid = value;
                NotifyPropertChanged();
            }
        }

        public new byte PageLayoutType
        {
            get
            {
                return base.PageLayoutType;
            }
            set
            {
                base.PageLayoutType = value;
                NotifyPropertChanged();
            }
        }

        public new bool IsPreferred
        {
            get
            {
                return base.IsPreferred;
            }
            set
            {
                base.IsPreferred = value;
                NotifyPropertChanged();
            }
        }

        public string ButtonMargin
        {
            get
            {
                int value = (int)Math.Floor(InnerSpacing);
                return $"{value},0,0,{value}";
            }
        }

        public string LabelMargin
        {
            get
            {
                int value = (int)Math.Floor(InnerSpacing) * 3;
                return $"{value},0,0,0";
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

        protected void NotifyPropertChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
