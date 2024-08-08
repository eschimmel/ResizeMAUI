namespace Microsoft.Maui.Devices
{
    public static class DeviceIdiomExtensions
    {
        public static byte ToByte(this DeviceIdiom deviceIdiom)
        {
            byte idiom = ResizeMAUI.Models.Constants.Idiom.Unknown;

            if (deviceIdiom == DeviceIdiom.Phone)
            {
                idiom = ResizeMAUI.Models.Constants.Idiom.Phone;
            }

            if (deviceIdiom == DeviceIdiom.Tablet)
            {
                idiom = ResizeMAUI.Models.Constants.Idiom.Tablet;
            }

            if (deviceIdiom == DeviceIdiom.Desktop)
            {
                idiom = ResizeMAUI.Models.Constants.Idiom.Desktop;
            }

            return idiom;
        }
    }
}

