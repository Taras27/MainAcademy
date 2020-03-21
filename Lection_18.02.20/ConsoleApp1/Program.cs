using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

   public class Program
    {
        static void DecoratedPrinter(string message) => Console.WriteLine($"*******{message}********");
        static int ReturnOne() => 1;
        static int ReturnTwo() => 2;

        public class Lib
        {
            private string[] _books =
            {
                "Book 1",
                "Book 2",
                "Book 3"
            };
            public string [] GetBooks (BooksFilter filter)
            {
                var results = new string[_books.Length];
                int books = 0;
                foreach(string book in _books)
                {
                    if(filter(book))
                    {
                        results[books++] = book;
                    }
                }
                return results;
            }

            public string[] Books => _books;
            private BookAddedHandler _bookAdded;

            public event BookAddedHandler BookAdded
            {
                add
                {
                    if(_bookAdded!=null)
                    {
                        var list = _bookAdded.GetInvocationList();
                        if(Array.IndexOf(list, value)>-1)
                        {
                            return;
                        }
                    }
                    _bookAdded += value;
                }
                remove
                {
                    _bookAdded -= value;
                }
            }

            public void AddBook (string bookName)
            {
                Array.Resize(ref _books, _books.Length + 1);
                _books[_books.Length - 1] = bookName;
                _bookAdded?.Invoke(this, bookName);
            }
        }

        static void Main()
        {
            #region

            Printer printer = Console.WriteLine;
            printer += DecoratedPrinter;
            printer += DecoratedPrinter;
            printer("Text");
            Console.WriteLine("Other text");
            #endregion

            #region

            ReturnSomeNum numberProvider = null;
            numberProvider += ReturnOne;
            numberProvider += ReturnTwo;
            var result = numberProvider();
            Console.WriteLine(result);

            Delegate[] invocationList = numberProvider.GetInvocationList();
            int sum = 0;
            foreach(var deleg in invocationList)
            {
                int num = (int)deleg.DynamicInvoke();
                sum += sum;
            }
            Console.WriteLine("Sum = {0}", sum);
            #endregion

            #region

            var lib = new Lib();
            /*
             BooksFilter filter = delegate (string bookName)
             {
                return bookName.Contains("1");
             }
             BooksFilter filter = bookName =>  bookName.Contains("1");

            BooksFilter filter = bookName =>
            {
                return bookName.Contains("1");
            }
             */

            var books = lib.GetBooks(bookName => bookName.Contains("1"));

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

            bool Filter (string bookName)
            {
                return bookName.Contains("1");
            }

            #endregion

            var newLib = new Lib();

            newLib.BookAdded += OnBookAdded;
            newLib.BookAdded += OnBookAdded;
            newLib.BookAdded += OnBookAdded;

            newLib.AddBook("C# for professionals");
            newLib.AddBook("Asp.Net Core 3 in detaols");
            Console.ReadKey();
        }

        private static void OnBookAdded (Lib l, string addedBookName)
        {
            Console.WriteLine($"Added new book {addedBookName}. Total books count: {l.Books.Length}");
        }

        public delegate void BookAddedHandler(Lib lib, string addedBookName);
        public delegate bool BooksFilter(string bookName);
        public delegate void Printer(string message);
        public delegate int ReturnSomeNum();
    }
}
