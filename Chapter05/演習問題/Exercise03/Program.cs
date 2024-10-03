using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            var text2 = "Jackdaws love my big sphinx of_quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
            Console.WriteLine("-----");

            Exercise3_6(text2);
        }

        private static void Exercise3_1(string text) {
            var spaces = text.Count(c => c == ' ');
            Console.WriteLine("空白数:{0}", spaces);
        }

        private static void Exercise3_2(string text) {
            var replaced = text.Replace("big", "small");
        }

        private static void Exercise3_3(string text) {
            /* var count = 0;
             var loopCount = text.Length;
             for (var i = 0; i < loopCount; i++) {
                 if (text.Substring(i, text.Length) == text) {

                     Console.WriteLine(count++);
                 }
             }*///↑間違えたプログラム
            int count = text.Split(' ').Length;
            Console.WriteLine("単語数:{0}", count);

        }

        private static void Exercise3_4(string text) {
            var words = text.Split(' ').Where(s => s.Length <= 4);
            foreach (var word in words) {
                Console.WriteLine(word);
            }
        }

        private static void Exercise3_5(string text) {
            //string[] words = text.Split(' ');
            var array = text.Split(' ').ToArray();

            /* var sb = new StringBuilder();
             foreach (var word in array) {
                 sb.Append(word);
             }

             text = sb.ToString();
             Console.WriteLine(text);*/
            if (array.Length > 0) {
                var sb = new StringBuilder(array[0]);
                foreach (var word in array.Skip(1)) {
                    sb.Append(' ');
                    sb.Append(word);
                }
                Console.WriteLine(sb);
            }

        }

        private static void Exercise3_6(string text) {
            var array = text.Split(new[] { ' ', ',', '-', '_' }).ToArray();
            foreach (var word in array) {
                Console.WriteLine(word);
            }
        }
    }
}
