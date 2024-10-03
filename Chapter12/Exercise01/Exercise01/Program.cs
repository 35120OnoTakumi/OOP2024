
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            Exercise1_1("employee.xml");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employee.xml"));
            Console.WriteLine();

            Exercise1_2("employees.xml");


            Exercise1_3("employees.xml");
            Console.WriteLine();

            Exercise1_4("employees.json");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employees.json"));
        }

        private static void Exercise1_1(string outfile) {
#if false

            var employee = new Employee {
                Id = 12,
                Name = "ビルゲイツ",
                HireDate = DateTime.Now,
            };
            var settings = new XmlWriterSettings {
                Encoding = new System.Text.UTF8Encoding(false),
                Indent = true,
                IndentChars = " ",
            };
            using (var writer = XmlWriter.Create("employee.xml", settings)) {
                var serializer = new XmlSerializer(employee.GetType());
                serializer.Serialize(writer, employee);
            }
#else
            using (var reader = XmlReader.Create("employee.xml")) {
                var serializer = new XmlSerializer(typeof(Employee));
                var empmloyee = serializer.Deserialize(reader) as Employee;
                Console.WriteLine(empmloyee);
            }
#endif
        }

        private static void Exercise1_2(string outfile) {

            var emps = new Employee[] {
                new Employee {
                    Id = 12,
                    Name = "ビルゲイツ",
                    HireDate = new DateTime(2001,5,10)
                },
                new Employee {
                    Id = 13,
                    Name = "イーロンマスク",
                    HireDate = new DateTime(2004,12,1)
                },
            };
            using (var writer = XmlWriter.Create(outfile)) {
                var serializer = new DataContractSerializer(emps.GetType());
                serializer.WriteObject(writer, emps);
            }
        }

        private static void Exercise1_3(string file) {

            //↓自回答
            /* using (var reader = XmlReader.Create("emps.xml")) {
                 var serializer = new XmlSerializer(typeof(EmployeeCollection));
                 var emps = serializer.Deserialize(reader) as EmployeeCollection;

                 /* foreach( var employee in emps.Employees) {
                      Console.WriteLine(employee);
                  }


             }*/
            //↓模範解答
            using (var reader = XmlReader.Create("emps.xml")) {
                var serializer = new XmlSerializer(typeof(Employee[]));
                var emps = serializer.Deserialize(reader) as Employee[];
                foreach (var employee in emps) {
                    Console.WriteLine("{0} {1} {2}", employee.Id, employee.Name, employee.HireDate);

                }
            }
        }

        private static void Exercise1_4(string file) {

            var emps = new Employee[] {
                new Employee {
                    Id = 12,
                    Name = "ビルゲイツ",
                    HireDate = new DateTime(2001,5,10)
                }
            };
            /*
#if false
            using (var stream = new FileStream(file, FileMode.Create,
                                                FileAccess.Write)) {
                var serializer = new DataContractJsonSerializer(emps.GetType());
                serializer.WriteObject(stream, file);
            }
#else
            var options = new JsonSerializerOptions {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };

            string jsonString = JsonSerializer.Serialize(emps, options);
            Console.WriteLine(jsonString);

#endif
            */
            using (var stream = new FileStream(file, FileMode.Create, FileAccess.Write)) {

                var option = new JsonSerializerOptions {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    WriteIndented = true,

                };
                JsonSerializer.Serialize(stream, emps, option);

            }

        }
    }
}
