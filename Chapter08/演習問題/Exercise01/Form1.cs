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
            DateTime.Now.ToString("ggyy年M月d日", culture);

            tbDisp.Text = DateTime.Now.ToString() + "\r\n" +
                          DateTime.Now.ToString("F\r\n") +
                          ("ggyy年M月d日", culture,dayOfWeek);
            
            */

            var dateTime = DateTime.Now;
            //2024/6/25 11:58
            var str1 = string.Format("{0:yyyy/M/d HH:mm}", dateTime);
            tbDisp.Text = str1 + "\r\n";

            //2019年01月15日 19時48分23秒
            var str2 = dateTime.ToString("yyyy年MM月dd日 HH時mm分ss秒");
            tbDisp.Text += str2 + "\r\n";

            //令和〇年〇日(〇曜日)
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var datestr = dateTime.ToString("ggyy", culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);

            var str3 = string.Format("{0}年{1,2}月{2,2}日({3})", datestr, dateTime.Month,
                                                                dateTime.Day, dayOfWeek);
            tbDisp.Text += str3;

        }

        private void btEx8_2_Click(object sender, EventArgs e) {

            var dateTime = DateTime.Now;
            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {

                var str = string.Format("{0:yy/MM/dd}の次週の{1}:", dateTime, (DayOfWeek)dayofweek);
                //tbDisp.Text += str + NextWeek(dateTime, (DayOfWeek)dayofweek) + "\r\n";

                tbDisp.Text += str + NextWeek(dateTime, (DayOfWeek)dayofweek) + "\r\n";

                //来週の日付を取得(戻り値受取)
                //NextWeek(dateTime,(DayOfWeek)dayofweek);
            }
        }

        //第1引数の日付の翌週のインスタンスを返却。第2引数で指定した翌週の曜日の日付インスタンス返却
        public static DateTime NextWeek(DateTime date, DayOfWeek dayOfWeek) {

            var nextweek = date.AddDays(7);
            var day = (int)dayOfWeek - (int)date.DayOfWeek;
            return nextweek.AddDays(day);
        }

        private void btEx8_3_Click(object sender, EventArgs e) {
            var tw = new TimeWatch();
            tw.Start();
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();
            var str = string.Format("処理時間は{0}ミリ秒",duration.TotalMilliseconds);
            tbDisp.Text += str + "\r\n";
        }
    }

    class TimeWatch {
        private DateTime _time;

        public void Start() {
            _time = DateTime.Now;
        }

        public TimeSpan Stop() {
            return DateTime.Now - _time;

        }
    }
}
