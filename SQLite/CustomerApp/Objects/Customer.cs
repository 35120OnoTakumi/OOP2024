using SQLite;
using System.IO;
using System.Windows.Media.Imaging;

namespace CustomerApp.Objects {
    public class Customer {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 電話番号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 住所
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 画像 (byte[] に変更)
        /// </summary>
        public byte[] ImageData { get; set; }

        public BitmapImage Image {
            get {
                if (ImageData == null || ImageData.Length == 0)
                    return null;
                using (var stream = new MemoryStream(ImageData)) {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = stream;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    return bitmap;
                }
            }
        }

        public override string ToString() {
            return $"{Id}   {Name}  {Phone}    {Address}";
        }
    }
}
