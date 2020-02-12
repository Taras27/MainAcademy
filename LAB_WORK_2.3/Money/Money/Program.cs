using System;

namespace Money
{
    class Program
    {
        static void Main(string[] args)
        {
            Money moneyOne = new Money(250, CurrencyType.USD);
            Money moneyTwo = new Money(250, CurrencyType.EU);
            Money moneyThree = new Money(100, CurrencyType.EU);
            Money moneyFor = new Money(250, CurrencyType.EU);

            Console.WriteLine("Operation ADD: {0}" , (moneyThree+moneyTwo).Amounth );

            double tmp = 12.45;
            moneyOne = moneyOne + tmp;
            Console.WriteLine("Operation ADD Double: {0}" , moneyOne.Amounth);

            moneyTwo--;
            Console.WriteLine("Operation --: {0}", moneyTwo.Amounth);

            moneyTwo++;
            Console.WriteLine("Operation ++: {0}", moneyTwo.Amounth);

            Console.WriteLine("Compare two object: {0}", moneyTwo != moneyThree);
            Console.WriteLine("Compare two object: {0}", moneyTwo == moneyFor);

            string tmpOne = "123";
            moneyOne = tmpOne;
            Console.WriteLine("String to double: {0}", moneyOne.Amounth);

            Console.WriteLine("Double to string: {0} \t {1}", moneyTwo.Amounth, moneyTwo.Type);
        }
    }
}
