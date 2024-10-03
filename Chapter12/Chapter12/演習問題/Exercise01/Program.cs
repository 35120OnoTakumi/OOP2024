using System;
using System.IO;
using System.Runtime.Serialization;
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
            var emp = new Employee {
                Id = 123,
                Name = "出井 秀行",
                HireDate = new DateTime(2001, 5, 10),
            };

            using (var writer = XmlWriter.Create(outfile)) {
                var serializer = new XmlSerializer(emp.GetType());
                serializer.Serialize(writer, emp);
            }
        }

        private static void Exercise1_2(string outfile) {
            var emps = new Employee[] {
                new Employee {
                    Id = 123,
                    Name = "出井 秀行",
                    HireDate = new DateTime(2001, 5, 10),
                },
                new Employee {
                    Id = 139,
                    Name = "大橋 孝仁",
                    HireDate = new DateTime(2004, 12, 1),
                },
            };
            using (var writer = XmlWriter.Create(outfile)) {
                var serializer = new DataContractSerializer(emps.GetType());
                serializer.WriteObject(writer, emps);
            }
        }

        private static void Exercise1_3(string file) {
            using (var reader = XmlReader.Create(file)) {
                var serializer = new DataContractSerializer(typeof(Employee[]));
                var emps = serializer.ReadObject(reader) as Employee[];
                foreach (var emp in emps) {
                    Console.WriteLine("{0} {1} {2}", emp.Id, emp.Name, emp.HireDate);
                }
            }
        }

        private static void Exercise1_4(string file) {
            var emps = new Employee[] {
                new Employee {
                    Id = 123,
                    Name = "出井 秀行",
                    HireDate = new DateTime(2001, 5, 10),
                },
                new Employee {
                    Id = 139,
                    Name = "大橋 孝仁",
                    HireDate = new DateTime(2004, 12, 1),
                },
            };

            using (var stream = new FileStream(file, FileMode.Create, FileAccess.Write)) {
                
                var options = new JsonSerializerOptions {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,  //キー名のカスタマイズ
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    WriteIndented = true,
                };

                JsonSerializer.Serialize(stream, emps, options);
            }

        }
    }
}
