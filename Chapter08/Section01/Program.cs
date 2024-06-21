using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            //指定した日付の曜日を求める和暦
            //あなたは平成〇〇年〇月〇日〇曜日に生まれました

            Console.WriteLine("生年月日を入力");
            Console.Write("年:");
            int year = int.Parse(Console.ReadLine());
            Console.Write("月:");
            int month = int.Parse(Console.ReadLine());
            Console.Write("日:");
            int day = int.Parse(Console.ReadLine());
            var birthday = new DateTime(year, month, day);

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var era = culture.DateTimeFormat.Calendar.GetEra(birthday);
            var eraName = culture.DateTimeFormat.GetEraName(era);

            var str = birthday.ToString("ggyy年M月d日dddd", culture);
            Console.WriteLine("あなたは" + str + "に生まれた");


            //あなたは生まれてから今日で○○日です
            var today = DateTime.Today;
            TimeSpan diff = today - birthday;
            Console.WriteLine("あなたが生まれてから今日で{0}日目です",
                                diff.Days + 1);



            //指定した日付の曜日を求める正答(入力値入)
            /* Console.WriteLine("生年月日を入力");
             Console.Write("年:");
             int year = int.Parse(Console.ReadLine());
             Console.Write("月:");
             int  month = int.Parse(Console.ReadLine());
             Console.Write("日:");
             int day = int.Parse(Console.ReadLine());

             var birthday = new DateTime(year,month,day);
             Console.WriteLine(birthday.ToString("dddd"));*/

            /*
            var dt1 = new DateTime(2024, 6, 19);
            var dt2 = new DateTime(2010, 3, 11, 13, 45, 20);
            Console.WriteLine(dt1);
            Console.WriteLine(dt2);

            var today = DateTime.Today;
            var now = DateTime.Now;
            Console.WriteLine("Today:{0}",today);
            Console.WriteLine("Now:{0}",now);

            var isLeapYear = DateTime.IsLeapYear(2024);
            if(isLeapYear) {
                Console.WriteLine("閏年");
            } else {
                Console.WriteLine("非閏年");
            }
            */


        }
    }
}
