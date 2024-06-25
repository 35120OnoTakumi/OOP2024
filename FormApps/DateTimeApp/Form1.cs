using System.Text.Json;

namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDateCount_Click(object sender, EventArgs e) {
            var today = DateTime.Today;

            TimeSpan diff = today - dtpDate.Value;
            //tbDisp.Text = "››“ú–Ú";
            tbDisp.Text = (diff.Days + 1) + "“ú–Ú";
        }
       

        private void btPrevious_Click(object sender, EventArgs e) {
            tbDisp.Text = nudDay.Value.ToString();
            var past = dtpDate.Value.AddDays(-(double)nudDay.Value);
            tbDisp.Text = past.ToString("D");
        }

        private void btDayafter_Click(object sender, EventArgs e) {

        }

        private void btAge_Click(object sender, EventArgs e) {
            var birthday = dtpDate.Value;
            var today = DateTime.Today;
            int age = GetAge(birthday, today);
            tbDisp.Text = age.ToString("D") + "Ë";
        }

        public static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }

    }
}
