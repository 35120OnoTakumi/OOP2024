using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //(演習)
            var prefecturalDic = new Dictionary<string, string>();
            for(int i = 0; i < 5; i++) {
                Console.WriteLine($"{i + 1}件目");
                Console.Write("都道府県:");
                var Key = Console.ReadLine();
                Console.Write("県庁所在地:");
                var Value = Console.ReadLine();

                /*if() {
                    Console.WriteLine("上書きするか");
                }*/

                    prefecturalDic.Add(Key, Value);

            }
            foreach(var ken in prefecturalDic) {

                Console.WriteLine($"{"都道府県:"}{ken.Key} " +
                                  $"{"県庁所在地:"}{ken.Value}");
            
            }






            /*
            var flowerDict = new Dictionary<string, int>() {
                { "sunflower", 400 },
                { "pansy", 300 },
                { "tulip", 350 },
                { "rose", 500 },
                { "dahlia", 450 },
            };
            Console.WriteLine(flowerDict["sunflower"]);
            Console.WriteLine(flowerDict["dahlia"]);
            
            var employeeDict = new Dictionary<int, Employee> {
               { 100, new Employee(100, "清水遼久") },
               { 112, new Employee(112, "芹沢洋和") },
               { 125, new Employee(125, "岩瀬奈央子") },
            };

            employeeDict.Add(126, new Employee(126, "庄野遥花"));

            var name = employeeDict.Where(e => e.Value.Name.Contains("和"));



            foreach (var item in employeeDict.Keys) {
                Console.WriteLine($"{item}");
            }
            /*
            // 以下、確認のためのコード
            var emp0 = employeeDict[100];
            Console.WriteLine($"{emp0.Id} {emp0.Name}");
            var emp1 = employeeDict[112];
            Console.WriteLine($"{emp1.Id} {emp1.Name}");
            var emp2 = employeeDict[125];
            Console.WriteLine($"{emp2.Id} {emp2.Name}");

            */

        }
    }
}
