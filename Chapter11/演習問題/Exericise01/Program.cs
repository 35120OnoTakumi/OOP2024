using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exericise01 {
    internal class Program {
        static void Main(string[] args) {
            var file = "sample.xml";
            Exercise1_1(file);
            Console.WriteLine();
            Exercise1_2(file);
            Console.WriteLine();
            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);

        }

        private static void Exercise1_1(string file) {
            var xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements()
                             .Select(x => new {
                                 Name = x.Element("name").Value,
                                 Teammembers = x.Element("teammembers").Value
                             }).ToList();
            foreach (var sport in sports) {
                Console.WriteLine("{0} {1}", sport.Name, sport.Teammembers);
            }
        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements()
                            .Select(x => new {
                                Name = x.Element("name").Attribute("kanji").Value,
                                Firstplayed = x.Element("firstplayed").Value,
                            }).OrderBy(x => x.Firstplayed);

            foreach (var sport in sports) {
                Console.WriteLine("{0}({1})", sport.Name, sport.Firstplayed);
            }

        }

        private static void Exercise1_3(string file) {
            var xdoc = XDocument.Load(file);
            var xelements = xdoc.Root.Elements().
            OrderByDescending(x => int.Parse(x.Element("teammembers").Value))
            .First();
            var xname = xelements.Element("name").Value;
            Console.WriteLine("{0}", xname);
        }

        private static void Exercise1_4(string file, string newfile) {
            List<XElement> xElemets = new List<XElement>();
            var xdoc = XDocument.Load(file);

            string name, kanji,
             teammembers, firstplayed;
            int nextFlag;

            while (true) {
                Console.Write("名称:");
                name = Console.ReadLine();
                Console.Write("漢字:");
                kanji = Console.ReadLine();
                Console.Write("人数:");
                teammembers = Console.ReadLine();
                Console.Write("起源:");
                firstplayed = Console.ReadLine();
                //1件分の要素作成
                var element = new XElement("ballsport",
                    new XElement("name", name, new XAttribute("kanji", kanji)),
                    new XElement("teammembers", teammembers),
                    new XElement("firstplayed", firstplayed)
                );
                xElemets.Add(element);//リストに要素追加
                Console.WriteLine(); //改行
                Console.Write("追加【1】保存【2】");
                Console.Write(">");
                nextFlag = int.Parse(Console.ReadLine());
                if (nextFlag == 2) break;//無限ループ脱出
                Console.WriteLine();//改行
            }
            xdoc.Root.Add(file);
            xdoc.Save(newfile);//保存

            /*do {
                Console.Write("名称:");
                string name = Console.ReadLine();
                Console.Write("漢字:");
                string kanji = Console.ReadLine();
                Console.Write("人数:");
                string teammembers = Console.ReadLine();
                Console.Write("起源:");
                string firstplayed = Console.ReadLine();

                Console.WriteLine("追加(1),保存(2)");
                string dejavu = Console.ReadLine();
                if(dejavu == "2") {
                    break;
                }
            } while (true);

            var xdoc = XDocument.Load("Sample.xml");
            xdoc.Root.Add(file);
            xdoc.Save(newfile);*/
        }
       

    }
}
