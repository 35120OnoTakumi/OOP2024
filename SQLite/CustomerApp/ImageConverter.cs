using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.IO;

namespace CustomerApp {
    public class ImageConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is byte[] imageBytes && imageBytes.Length > 0) {
                var bitmapImage = new BitmapImage();
                using (var stream = new MemoryStream(imageBytes)) {
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = stream;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                }
                return bitmapImage;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}