using System;


namespace ConsoleApp1
{
    class Program
    {
       public delegate string MyDelegat(string name);
       public delegate void MyDelegat1();
        static void Main(string[] args)
        {
            #region Delagate
            //MyDelegat myDelegat = new MyDelegat(MyMethod);
            //MyDelegat1 myDelegat1 = MyMethod1;
            //MyDelegat1 myDelegat2 = MyMethod2;
            //myDelegat1 += MyMethod2;
            //myDelegat1.Invoke();

            //MyDelegat1 myDelegat3 =  myDelegat2  + myDelegat1;
            //myDelegat3.Invoke();

            //int[] arr = {23, 34, 66, 78, 99 };

            ////Console.WriteLine(myDelegat("Horyn Taras"));

            //Func<string, string> func = MyMethod;
            //Console.WriteLine(func.Invoke("Taras Horyn!"));
            ////Console.WriteLine(((Func<string, string>)MyMethod).Invoke("Taras Horyn!"));

            //Predicate<int> predicate = Compare;
            //int arrO = Array.Find(arr, predicate);
            //Console.WriteLine(arrO.ToString());

            //Action<string> action1 = MyMethod3;
            //action1.Invoke("Name!");

            //Action action = MyMethod1;
            //action += MyMethod2;
            //action += MyMethod2;
            //action -= MyMethod1;
            //action.Invoke();
            #endregion



            Console.ReadLine();
        }

        #region
        public static void MyMethod1 ()
        {
            Console.WriteLine("Hello MyMethod1!!!");
        }

        public static void MyMethod2()
        {
            Console.WriteLine("Hello MyMethod2!!!");
        }
        public static string MyMethod (string name)
        {
            return name;
        }

        public static void MyMethod3(string name)
        {
            Console.WriteLine(name);
        }

        public static bool Compare (int arr)
        {
            int key = 99;
            if (key == arr)
            {
                return true;
            }            
            return false;
        }
        #endregion


    }
}
