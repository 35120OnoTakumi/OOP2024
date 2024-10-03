using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            foreach (var pair in line.Split(';')) {
                var array = pair.Split('=');
                Console.WriteLine("{0} : {1}", ToJapanese(array[0]), array[1]);
            }
        }

        //できたら以下のメソッドを完成させて利用する
        static string ToJapanese(string key) {
            switch (key) {

                case "Novelist":
                    return "作家";


                case "BestWork":
                    return "代表作";

                case "Born":
                    return "誕生日";
            }
            throw new ArgumentException("引数が違う");
        }
    }
}
