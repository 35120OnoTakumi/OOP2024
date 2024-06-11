using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amari {
    internal class Program {
        static void Main(string[] args) {

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
            /*
            var prefecturalDic = new Dictionary<string, string>();
            //入力処理
            for(int i = 0; i < 5; i++) {
                //都道府県の入力
                Console.WriteLine($"{i + 1}件目");
                Console.Write("都道府県:");
                String Key = Console.ReadLine();
                //県庁所在地の入力
                Console.Write("県庁所在地:");
                String Value = Console.ReadLine();
                //既に都道府県が登録されているのか
                if(prefecturalDic.ContainsKey(Key)) {
                    //登録済
                    Console.WriteLine("上書き(Yes or No)");
                    //上書きする
                    if (Console.ReadLine() == "Yes") {
                        prefecturalDic[Key] = Value;                  
                    }//上書きしない
                    else {
                        continue;
                    }
                } else {
                    //未登録
                    prefecturalDic.Add(Key, Value);
                }
                

                //Dictionaryへ登録



                

                //Yes...Dictionaryへ登録

                //No...次の登録へ

                prefecturalDic.Add(Key, Value);

            }
            
            Boolean endFlag = false;//終了フラグ(ループから脱出)
            while (true) {
                Console.WriteLine("***メニュー***");
                Console.WriteLine("1:一覧表示");
                Console.WriteLine("2:検索");
                Console.WriteLine("9:終了");
                String menuSelect = Console.ReadLine();
                switch(menuSelect) {
                    case "1":
                        //一覧処理出力
                        foreach (var item in prefecturalDic) {
                            Console.WriteLine("{0}の県庁所在地は{1}", item.Key, item.Value);
                        }

                        break;
                        
                    case "2":
                        //都道府県の入力
                        Console.WriteLine("都道府県");
                        String searchPref = Console.ReadLine();
                        Console.WriteLine(searchPref + "の県庁所在地は" + prefecturalDic[searchPref]);

                        break;

                    case "9":
                        endFlag = true;
                        break;

                }
                if (endFlag) {
                    break;
                }
            }
            */
        }
    }
}
