using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Dtrpt
    {
        struct Demo
        {
            public string S1;
            public string S2;

            public Demo (string s1, string s2)
            {
                S1 = s1;
                S2 = s2;
            }
        }
    }

    class User
    {
        //public User () : this ("NONAME")
        //{
        //}
        //public User(string name) : this(name, -1)
        //{
        //}
        //public User(string name, int age)
        //{
        //    this._name = name;
        //    this._age = age;
        //}
        //public User (User user) : this (user._name, user._age)
        //{
        //}

        ////public string Name { get; } = " ";
        //public string Name
        //{
        //    get { return _name; }
        //    set { _name = value; }
        //}
        //public int Age
        //{
        //    get { return _age; }
        //    set { _age = value; }
        //}
        //private string _name;
        //private int _age;

        private string _middleName;

        public User (string firstName, string lastName, string middleName = null)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; }
        public string MiddleName
        {
            get => _middleName;
            set => _middleName = value?.Trim();
        }
        public string FullName
        {
            get
            {
                string fName = string.Join(" ", LastName, FirstName);
                if(!string.IsNullOrEmpty(MiddleName))
                {
                    fName += " " + MiddleName;
                }
                return fName;
            }
        }

        public char this [int idx]
        {
            get => FirstName[idx];
            set
            {
                var chars = FirstName.ToCharArray();
                chars[idx] = value;
                FirstName = new string(chars);
            }
        }
    }
    class Program
    {
        public static int RecursiveMull (int a)
        {               
            if (a % 2 == 0)
            {
                return a * RecursiveMull(a-1);
            }
             else if (a == 1)
             {
                 return 1;
             }
             return RecursiveMull(a-1);
        }
        static void Main(string[] args)
        {
            User tmp = new User(" " , " ");
            Console.WriteLine(tmp.FullName);

            Console.WriteLine(RecursiveMull(7));
            Console.ReadKey();
        }
    }
    
}
