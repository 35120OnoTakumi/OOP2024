using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {
            /*
            var date = DateTime.Now;
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetDayName(date.DayOfWeek);
            DateTime.Now.ToString("ggyy”NMŒd“ú", culture);

            tbDisp.Text = DateTime.Now.ToString() + "\r\n" +
                          DateTime.Now.ToString("F\r\n") +
                          ("ggyy”NMŒd“ú", culture,dayOfWeek);
            
            */

            var dateTime = DateTime.Now;
            //2024/6/25 11:58
            var str1 = string.Format("{0:yyyy/M/d HH:mm}", dateTime);
            tbDisp.Text = str1 + "\r\n";

            //2019”N01Œ15“ú 1948•ª23•b
            var str2 = dateTime.ToString("yyyy”NMMŒdd“ú HHmm•ªss•b");
            tbDisp.Text += str2 + "\r\n";

            //—ß˜aZ”NZ“ú(Z—j“ú)
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var datestr = dateTime.ToString("ggyy",culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);

            var str3 = string.Format("{0}”N{1,2}Œ{2,2}“ú({3})", datestr, dateTime.Month,
                                                                dateTime.Day, dayOfWeek);
            tbDisp.Text += str3;

        }
    }
}
