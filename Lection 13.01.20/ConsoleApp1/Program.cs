using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string verbatimStr = @"Some """"
            //string";
            //Console.WriteLine(verbatimStr);


            //string template = $"Hello {name}, happy new year!!!";  інтерпольовані строки

            //char[] symbols = { 'H', 'H', 'H', 'H', 'H' };
            //var fromArray = new string(symbols);

            //var delim = new string('-', 60);
            //Console.WriteLine(fromArray);
            //Console.WriteLine(delim);

            //composite formating ->
            //string name = "demoUser";
            //string formated = string.Format("Hello {0} happy new year '{1,10:x8}'!!!", name, 2020);
            //                                                              //^
            //                                                              //|
            //                                                    //{index, alignement:format}
            //Console.WriteLine(formated);

            // - Trim

            //string withSpaces = "    H    ";
            //string somePath = "/path/to/dir";
            //string someUrl = "https://domain.com/path/";
            //Console.WriteLine(withSpaces);
            //Console.WriteLine(somePath);
            //Console.WriteLine(someUrl);
            //string trimSoaces = withSpaces.Trim(' ');
            //string pathTrim = somePath.TrimStart('/');
            //string trimmedUrl = someUrl.TrimEnd('/');
            //Console.WriteLine(trimSoaces);
            //Console.WriteLine(pathTrim);
            //Console.WriteLine(trimmedUrl);

            // Split
            //string numberStr = "1,2,,3, ,4,5,";
            //string[] nums = numberStr.Split(new[] { ',',' ' },StringSplitOptions.RemoveEmptyEntries);

            // Compare
            //int res = string.Compare("abc","ABC");
            //string formattedNum = string.Format(CultureInfo.InvariantCulture, "{0:C}", 22.654321);
            //Console.WriteLine(formattedNum);

            // String.join
            //string[] names = { "John", "Annet", "Bill" };
            //string joinedNames = string.Join(",", names);
            //Console.WriteLine(joinedNames);
            //Console.WriteLine( "{0} {1} {2}",names[0], names[1], names[2]);

            //padLeft,padRight
            //Console.WriteLine("name".PadRight(10,'*'));

            //string[] collums = { "Name", "Birthday", "Age" };
            //string[,] data =
            //{
            //    { "Bill", "1970/11/11", "40"  },
            //    { "Alice", "1970/11/11", "40" },
            //    { "John", "1970/11/11", "40"  }
            //};

            //string delim = new string('-', 60);
            //Console.WriteLine(delim);

            //for(int i=0; i<data.GetLength(0);i++)
            //{
            //    string[] toDisplay = new string[data.GetLength(1)]; 
            //    for(int j=0; j<data.GetLength(1); j++)
            //    {
            //        toDisplay[j] = data[i, j].PadLeft(15);
            //    }
            //}

            //string emptyStr = null;
            //string emptyStr2 = " ";
            //bool isEmpty = string.IsNullOrEmpty(emptyStr);
            //bool isEmpty2 = string.IsNullOrWhiteSpace(emptyStr2);

            // String.Contains

            //string text = "Some text";
            //bool contains = text.Contains("text");

            // String.Substring
            //string html = "<li>Some content</li>";
            //int startIndx = html.IndexOf(">") + 1;
            //int count = html.Length - startIndx - "</li>".Length;
            ////string content = html.Substring(startIndx, count);            
            //string content = html[startIndx  ..^5];
            //Console.WriteLine(content);

            // insert/remove

            string src = "Some code";
            string res = src.Insert(0, "</li>");
            Console.WriteLine(res);          
        }
    }
}
