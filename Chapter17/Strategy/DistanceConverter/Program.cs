using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    class Program {
        static void Main(string[] args) {
            while (true) {
                var from = GetConverter("変換元の単位入力");
                var to = GetConverter("変換先単位入力");
                var distance = GetDistance(from);

                var converter = new DistanceConverter(from, to);
                var result = converter.Convert(distance);
                Console.WriteLine($"{distance}{from.UnitName}" +
                                  $"は{result:0.000}{to.UnitName}\n");
            }

        }

        //変換したい距離入力
        static double GetDistance(ConverterBase from) {
            double? value = null;
            do {
                Console.Write($"変換したい距離(単位:{from.UnitName})を入力 => ");
                var line = Console.ReadLine();
                double temp;
                value = double.TryParse(line, out temp) ? (double?)temp : null;
            } while (value == null);
            return value.Value;
        }

        static ConverterBase GetConverter(string msg) {
            ConverterBase converter = null;
            do {
                Console.Write(msg + " => ");
                var unit = Console.ReadLine();
                converter = ConverterFactory.GetInstance(unit);

            } while (converter == null);
            return converter;
        }

    }
}
