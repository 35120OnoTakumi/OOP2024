using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var books = Books.GetBooks().OrderByDescending(x => x.Price).ToList();

            books.ForEach(x => Console.WriteLine(x.Title + ":" + x.Price));

            /*
            foreach (var book in books) {
                Console.WriteLine(book.Title + ":" + book.Price);
            }
            */
        }
    }
}
