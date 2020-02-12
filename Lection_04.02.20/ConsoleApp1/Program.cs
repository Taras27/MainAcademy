using System;

namespace ConsoleApp1
{
    class Program
    {
        public partial class PartialDemo : ICloneable
        {
            private int _value;
            public int Value
            {
                get => _value;
                set 
                {
                    OnValueSet(ref value);
                    _value = value;
                }
            }
            partial void OnValueSet(ref int value);
            partial void OnCall();
            public static void PrintValues(
                string name, int age)
            {
                Console.WriteLine($"Name is:{ name}, Age is:{age}");
            }
            public void Disponce()
            {

            }
        }
    }
}
