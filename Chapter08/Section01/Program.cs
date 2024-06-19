using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
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
        }
    }
}
