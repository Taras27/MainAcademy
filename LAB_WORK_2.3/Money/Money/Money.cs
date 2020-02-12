using System;
using System.Collections.Generic;
using System.Text;

namespace Money
{
    enum CurrencyType
    {
        UAH=1,
        USD,
        EU
    };    
    class Money
    {
        private double amount;
        private CurrencyType type;

        public double Amounth
        {
            get => amount;
            set => amount = value;
        }
        public CurrencyType Type
        {
            get => type;
            set => type = value;
        }        
        public Money ()
        {
            amount = 0;
            type = 0;
        }

        public Money(double Amounth)
        {
            amount = Amounth;            
        }

        public Money (double Amounth, CurrencyType Type)
        {
            amount = Amounth;
            type = Type;
        }
       
        public static Money operator +(Money moneyOne, Money moneyTwo)
        {
            if(moneyOne.Type == moneyTwo.Type)
                return new Money(moneyOne.amount + moneyTwo.amount, moneyOne.Type);
            else
            {
                Console.WriteLine("Різні типи валюти!!!");
                return new Money();
            }
        }

        public static Money operator --(Money moneyOne)
        {          
            return new Money(--moneyOne.amount, moneyOne.Type);            
        }

        public static Money operator ++(Money moneyOne)
        {
            return new Money(++moneyOne.amount, moneyOne.Type);
        }

        public static Money operator *(Money moneyOne, Money moneyTwo)
        {
            return new Money(moneyOne.amount * 3 * moneyTwo.amount);
        }

        public static bool operator >(Money moneyOne, Money moneyTwo)
        {
            if (moneyOne.amount > moneyTwo.amount && moneyOne.type == moneyTwo.type)
                return true;
            else
                return false;
        }

        public static bool operator ==(Money moneyOne, Money moneyTwo)
        {
            if (moneyOne.amount == moneyTwo.amount && moneyOne.type == moneyTwo.type)
                return true;
            else
                return false;
        }

        public static bool operator !=(Money moneyOne, Money moneyTwo)
        {
            if (moneyOne.amount != moneyTwo.amount && moneyOne.type == moneyTwo.type)
                return true;
            else
                return false;
        }
        public static bool operator <(Money moneyOne, Money moneyTwo)
        {
            if (moneyOne.amount < moneyTwo.amount && moneyOne.type == moneyTwo.type)
                return moneyOne.amount < moneyTwo.amount;
            else
                return moneyTwo.amount < moneyOne.amount;
        }

        public static bool operator true(Money money)
        {
            return money.type == CurrencyType.USD;
        }
        public static bool operator false(Money money)
        {
           return money.type == CurrencyType.UAH;           
        }

        public static  implicit operator Money(double money) => new Money(money, CurrencyType.USD);

        public static implicit operator Money(string money) => new Money(Convert.ToDouble(money));

        public static explicit operator double(Money money) =>  money.amount;

        public static explicit operator string(Money money) => Convert.ToString(money.amount);
    }
}
