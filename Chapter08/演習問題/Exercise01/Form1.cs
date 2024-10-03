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
            DateTime.Now.ToString("ggyy�NM��d��", culture);

            tbDisp.Text = DateTime.Now.ToString() + "\r\n" +
                          DateTime.Now.ToString("F\r\n") +
                          ("ggyy�NM��d��", culture,dayOfWeek);
            
            */

            var dateTime = DateTime.Now;
            //2024/6/25 11:58
            var str1 = string.Format("{0:yyyy/M/d HH:mm}", dateTime);
            tbDisp.Text = str1 + "\r\n";

            //2019�N01��15�� 19��48��23�b
            var str2 = dateTime.ToString("yyyy�NMM��dd�� HH��mm��ss�b");
            tbDisp.Text += str2 + "\r\n";

            //�ߘa�Z�N�Z��(�Z�j��)
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var datestr = dateTime.ToString("ggyy", culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);

            var str3 = string.Format("{0}�N{1,2}��{2,2}��({3})", datestr, dateTime.Month,
                                                                dateTime.Day, dayOfWeek);
            tbDisp.Text += str3;

        }

        private void btEx8_2_Click(object sender, EventArgs e) {

            var dateTime = DateTime.Now;
            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {

                var str = string.Format("{0:yy/MM/dd}�̎��T��{1}:", dateTime, (DayOfWeek)dayofweek);
                //tbDisp.Text += str + NextWeek(dateTime, (DayOfWeek)dayofweek) + "\r\n";

                tbDisp.Text += str + NextWeek(dateTime, (DayOfWeek)dayofweek) + "\r\n";

                //���T�̓��t���擾(�߂�l���)
                //NextWeek(dateTime,(DayOfWeek)dayofweek);
            }
        }

        //��1�����̓��t�̗��T�̃C���X�^���X��ԋp�B��2�����Ŏw�肵�����T�̗j���̓��t�C���X�^���X�ԋp
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
            var str = string.Format("�������Ԃ�{0}�~���b",duration.TotalMilliseconds);
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
