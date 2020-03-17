using System;

namespace Delegate
{
    public delegate void MyDelegate();

    public delegate string MyDelegateString(string name);
    public class someClass
    {
        public string SomeMethod(string s)
        {
            return $"Hello -> {s}";
        }

    }

    class Program
    {
        public static void MyMethod1()
        {
            Console.WriteLine("MyMethod1");
        }

        public static void MyMethod2()
        {
            Console.WriteLine("MyMethod2");
        }

        public static void MyMethod3()
        {
            Console.WriteLine("MyMethod3");
        }
        static void Main(string[] args)
        {
            someClass SomeClass = new someClass();

            MyDelegate myDelegate = null;

            MyDelegate myDelegate4 = null;

            MyDelegate myDelegate1 = new MyDelegate(MyMethod1);

            MyDelegate myDelegate2 = new MyDelegate(MyMethod2);

            MyDelegate myDelegate3 = new MyDelegate(MyMethod3);

            MyDelegateString myDelegateString = new MyDelegateString(SomeClass.SomeMethod);

            myDelegate = myDelegate1 + myDelegate2 + myDelegate3;
            myDelegate.Invoke();
           
            myDelegate4 = myDelegate - myDelegate1;
            myDelegate4.Invoke();

            Console.WriteLine(SomeClass.SomeMethod("User"));
            
            Console.WriteLine(myDelegateString.Invoke("UserTwo"));

            Console.ReadKey();
        }
    }
}
