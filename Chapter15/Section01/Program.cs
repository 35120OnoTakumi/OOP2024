using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var groups = Library.Books
                .GroupBy(b => b.PublishedYear)
                .OrderBy(g => g.Key);

            foreach (var g in groups) {
                Console.WriteLine($"{g.Key}年");
                foreach (var book in g) {
                    Console.WriteLine($"{book}");
                }
            }

        }
    }
}
