using SampleEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework {
    internal class Program {
        static void Main(string[] args) {

            //AddAuthors();
            //AddBooks();
            // DisplayAllBooks();

            Console.WriteLine("# 1.2");
            DisplayAllBooks2();
            

            //GetBooks();↓正答
            /*  foreach (var book in GetBooks()) {
                  Console.WriteLine(book.Title);
              }*/
            //DisplayAllBooks();自分の回答(データをコンソールに表示)
            //InsertBooks();

            Console.WriteLine();
            Console.WriteLine("# 1.3");
            DisplayAllBooks3();

            Console.WriteLine();
            Console.WriteLine("# 1.4");
            Exercise1_4();

            Console.WriteLine();
            Console.WriteLine("# 1.5");
            Exercise1_5();

            Console.ReadLine(); 
           //↑コンソールアプリだが F5 でデバッグ実行したいために記述
        }

        //13.1.2
        static void DisplayAllBooks2() {
            using (var db = new BooksDbContext()) {
                foreach (var book in db.Books.ToList()) {
                    Console.WriteLine("{0} {1} {2} ({3:yyyy/MM/dd})",
                        book.Title, book.PublishedYear,
                        book.Author.Name, book.Author.Birthday
                    );
                }
            }
        }


        //13.1.3
        static void DisplayAllBooks3() {
            using (var db = new BooksDbContext()) {
                var books = db.Books.Where(b => b.Title.Length ==
                            db.Books.Max(x => x.Title.Length)).ToList();
                foreach (var item in books) {
                    Console.WriteLine(item.Title);
                }
            }
        }


        //13.1.4
        private static void Exercise1_4() {
            using (var db = new BooksDbContext()) {
                var books = db.Books
                             .OrderBy(b => b.PublishedYear)
                             .Include(nameof(Author))
                             .Take(3);
                foreach (var book in books) {
                    Console.WriteLine("{0} {1} {2}",
                        book.Title, book.PublishedYear, book.Author.Name);
                }
            }
        }
        //13.1.5
        private static void Exercise1_5() {
            using (var db = new BooksDbContext()) {
                var authors = db.Authors.OrderByDescending(a => a.Birthday).ToList();

                foreach (var author in authors) {
                    Console.WriteLine("{0}",author.Name);
                    foreach (var book in author.Books) {
                        Console.WriteLine("{0} {1}",book.Title,book.PublishedYear);
                    }
                }
                            
            }

        }

        //データ削除
        private static void DeleteBook() {
            using (var db = new BooksDbContext()) {
                var book = db.Books.SingleOrDefault(x => x.Id == 10);
                if (book != null) {
                    db.Books.Remove(book);
                    db.SaveChanges();//データベース更新
                }
            }
        }

        //データ変更
        private static void UpdateBook() {
            using (var db = new BooksDbContext()) {
                var book = db.Books.Single(x => x.Title == "銀河鉄道の夜");
                book.PublishedYear = 2016;
                db.SaveChanges();//データベース更新
            }
        }

        //自分の回答(データをコンソールに表示)
        /*static void DisplayAllBooks() {
             var books = GetBooks();
             foreach(var book in books) {
                 Console.WriteLine($"{ book.Title}{book.PublishedYear}");
             }

             Console.ReadLine();
         }*/

        //著者追加
        private static void AddAuthors() {

            using (var db = new BooksDbContext()) {
                /*   var author1 = new Author {
                       Birthday = new DateTime(1878, 12, 7),
                       Gender = "F",
                       Name = "与謝野晶子",
                   };
                   db.Authors.Add(author1);

                   var author2 = new Author {
                       Birthday = new DateTime(1896, 8, 27),
                       Gender = "M",
                       Name = "宮沢賢治",
                   };
                   db.Authors.Add(author2);*/

                var author3 = new Author {
                    Birthday = new DateTime(1888, 12, 26),
                    Gender = "M",
                    Name = "菊池寛",
                };
                db.Authors.Add(author3);

                var author4 = new Author {
                    Birthday = new DateTime(1899, 6, 14),
                    Gender = "M",
                    Name = "川端康成",
                };
                db.Authors.Add(author4);
                db.SaveChanges();//データベース更新
            }
        }

        //書籍追加
        private static void AddBooks() {
            using (var db = new BooksDbContext()) {
                var author1 = db.Authors.Single(a => a.Name == "与謝野晶子");
                var book1 = new Book {
                    Title = "みだれ髪",
                    PublishedYear = 2000,
                    Author = author1,
                };
                db.Books.Add(book1);

                var author2 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book2 = new Book {
                    Title = "銀河鉄道の夜",
                    PublishedYear = 1989,
                    Author = author2,
                };
                db.Books.Add(book2);

                var author3 = db.Authors.Single(a => a.Name == "菊池寛");
                var book3 = new Book {
                    Title = "真珠婦人",
                    PublishedYear = 2002,
                    Author = author3,
                };
                db.Books.Add(book3);

                var author4 = db.Authors.Single(a => a.Name == "川端康成");
                var book4 = new Book {
                    Title = "伊豆の踊子",
                    PublishedYear = 2003,
                    Author = author4,
                };
                db.Books.Add(book4);

                var author5 = db.Authors.Single(a => a.Name == "夏目漱石");
                var book5 = new Book {
                    Title = "こころ",
                    PublishedYear = 1991,
                    Author = author5,
                };
                db.Books.Add(book5);

                var author6 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book6 = new Book {
                    Title = "注文の多い料理店",
                    PublishedYear = 2000,
                    Author = author6,
                };
                db.Books.Add(book6);
                db.SaveChanges();//データベース更新
            }
        }

        static void InsertBooks() {
            using (var db = new BooksDbContext()) {
                var book1 = new Book {
                    Title = "坊ちゃん",
                    PublishedYear = 2003,
                    Author = new Author {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石",
                    }
                };
                db.Books.Add(book1);

                var book2 = new Book {
                    Title = "人間失格",
                    PublishedYear = 1990,
                    Author = new Author {
                        Birthday = new DateTime(1909, 6, 19),
                        Gender = "M",
                        Name = "太宰治",
                    }
                };
                db.Books.Add(book2);
                db.SaveChanges();   //データベースを更新
            }
        }

        //テーブル全表示
        static void DisplayAllBooks() {
            var books = GetBooks();
            foreach (var book in books) {
                Console.WriteLine($"{book.Title} {book.PublishedYear}");
            }
            Console.ReadLine();
        }

        static IEnumerable<Book> GetBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books
                               // .Where(book => book.Author.Name.StartsWith("夏目"))
                               .ToList();
            }
        }
    }
}
