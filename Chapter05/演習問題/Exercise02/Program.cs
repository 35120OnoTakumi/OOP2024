using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var line = Console.ReadLine();
            int num;
            if (int.TryParse(line, out num)) {
                int.TryParse(line, out num);
                Console.WriteLine($"{num:#,#}");
                // Console.WriteLine("{0:#,#}",num);
            } else {
                Console.WriteLine("数字文字列でない");
            }
        }
    }
}
