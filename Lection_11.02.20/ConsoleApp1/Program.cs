using System;

namespace ConsoleApp1
{
    public enum OrderStatus
    {
        Created,
        Approved,
        Delivered,
        Canseled
    }

    public class Order
    {
        public Order(string productList, decimal totalPrise)
        {
            if (string.IsNullOrWhiteSpace(productList))
                throw new ArgumentNullException();
            if(totalPrise <= 0)
                throw new ArgumentNullException();

            ProductList = productList;
            TotalPrise = totalPrise;
        }
        public OrderStatus Status { get; private set; }
        public string ProductList { get; private set; }
        public decimal TotalPrise { get; private set; }

        public void Deliver()
        {
            if (Status != OrderStatus.Approved)
            {
                throw new InvalidOperationException();
            }
            Status = OrderStatus.Delivered;
        }

        public void Approve()
        {
            if (Status != OrderStatus.Created)
            {
                throw new InvalidOperationException();
            }
            Status = OrderStatus.Approved;
        }

        public void Cansel()
        {
            if (Status != OrderStatus.Delivered)
            {
                throw new InvalidOperationException();
            }
            Status = OrderStatus.Canseled;
        }
    }

    public class OrderStatusTransitionException : Exception
    {
        public OrderStatusTransitionException(OrderStatus from, OrderStatus to)
            : base("Unable to change status " +
                 $"from '{from}' to '{to}'")
        {
            From = from;
            To = to;
        }
        public OrderStatus From { get; private set; }
        public OrderStatus To { get; private set; }

    }

    class Program
    {
        
        static void Main(string[] args)
        {
            var o = new Order("Dog, Pizza, Cup", 120);
            Console.WriteLine(o.Status);

            o.Approve();
            Console.WriteLine(o.Status);

            o.Deliver();
            Console.WriteLine(o.Status);

            try
            {
                CanselOrder(o);
            }
            catch (OrderStatusTransitionException e)
            {
                Console.WriteLine(e);
            }
            static void CanselOrder (Order o)
            {
                try
                {
                    o.Cansel();
                }
                catch(InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    throw new OrderStatusTransitionException(o.Status, OrderStatus.Canseled);
                }
            }
        }
        static void Metod2()   
        {
            try
            {
                object o = null;
                o.ToString();
                Console.WriteLine("After possible exception!");
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }
    }

    //try
           // {
           //     Metod2();
           // }
           //catch (NullReferenceException exc)
           //{
           //     Console.WriteLine("NRE" + exc.Message);
           //}
           // catch(IndexOutOfRangeException)
           // {
           //     Console.WriteLine("IORE");
           // }
           // catch (Exception exc)
           // {
           //     Console.WriteLine("OOPS" + exc.Message);
           // }
}
