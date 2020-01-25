using System;
using System.Threading;

namespace AirPortPanell
{
    class Program
    {
        enum Status
        {
            Check_in=1,
            Gate_Closed,
            Arrived,
            Departed_at,
            Unknown,
            Canseled,
            Expected_at,
            Delayed,
            In_flight
        }
        struct flyingInfo
        {
            public string timeArrival; //
            public string timeDeparture; //
            public string flightNumber;//
            public string cityOfArrival;//
            public string cityOfDeparture;//
            public string airLines;//
            public string terminal;//
            public Status flyingStatus;//
            public string gate;//
        }

        static flyingInfo[] myFlying  = new flyingInfo[20];
        public static int flyingCount = 0;
        static void Main(string[] args)
        {
            while(flyingCount != 20)
            {
                Console.Clear();
                Console.WriteLine("Chiose function:" +
                    "\r\n\tAdd arrival or departure: 1" +
                    "\r\n\tShow main table: 2" +
                    "\r\n\tEdit arrival or departure: 3" +
                    "\r\n\tSearch fligt: 4");
                int userChoise = int.Parse(Console.ReadLine());
                switch(userChoise)
                {
                    case 1://Add arrival or departure: 1
                        Console.Clear();
                        addFly(flyingCount);
                        flyingCount++;
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;

                    case 2://Show fly: 2
                        Console.Clear();
                        showMainHat();
                        showTableHat();
                        showFly();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;

                    case 3://edit flying: 3
                        Console.Clear();                        
                        Console.WriteLine("Choise flight to edit:" +
                            "\r\n\trange 1 - 20");
                        int editFlight = int.Parse(Console.ReadLine());
                        editFly(editFlight-1);
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;

                    case 4: //search fly
                        Console.Clear();
                        showMainHat();
                        showTableHat();

                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static void addFly(int numFly)
        {
            Console.WriteLine("Enter time departure:");
            myFlying[numFly].timeDeparture = Console.ReadLine();

            Console.WriteLine("Enter time arrival:");
            myFlying[numFly].timeArrival = Console.ReadLine();

            Console.WriteLine("Enter flight number:");
            myFlying[numFly].flightNumber = Console.ReadLine();

            Console.WriteLine("Enter city of arrival:");
            myFlying[numFly].cityOfArrival = Console.ReadLine();
            
            Console.WriteLine("Enter city of departure:");
            myFlying[numFly].cityOfDeparture = Console.ReadLine();

            Console.WriteLine("Enter airlines:");
            myFlying[numFly].airLines = Console.ReadLine();

            Console.WriteLine("Enter terminal:");
            myFlying[numFly].terminal = Console.ReadLine();

            Console.WriteLine("Enter flight status:" +
                "\r\n\tCheck in: 1" +
                "\r\n\tGate closed: 2" +
                "\r\n\tArrived: 3" +
                "\r\n\tDeparted at: 4" +
                "\r\n\tUnknown: 5" +
                "\r\n\tCanseled: 6" +
                "\r\n\tExpected at: 7" +
                "\r\n\tDelayed: 8" +
                "\r\n\tIn_flight: 9");
            int tmp = int.Parse(Console.ReadLine());
            Status num = (Status)tmp;
            switch(num)
            {
                case Status.Check_in: myFlying[numFly].flyingStatus = Status.Check_in; break;
                case Status.Gate_Closed: myFlying[numFly].flyingStatus = Status.Gate_Closed; break;
                case Status.Arrived: myFlying[numFly].flyingStatus = Status.Arrived; break;
                case Status.Departed_at: myFlying[numFly].flyingStatus = Status.Departed_at; break;
                case Status.Unknown: myFlying[numFly].flyingStatus = Status.Unknown; break;
                case Status.Canseled: myFlying[numFly].flyingStatus = Status.Canseled; break;
                case Status.Expected_at: myFlying[numFly].flyingStatus = Status.Expected_at; break;
                case Status.Delayed: myFlying[numFly].flyingStatus = Status.Delayed; break;
                case Status.In_flight: myFlying[numFly].flyingStatus = Status.In_flight; break;
            }

            Console.WriteLine("Gate:");
            myFlying[numFly].gate = Console.ReadLine();
        }

        public static void showFly()
        {            
            string strTmp = null;
            for(int tmp = 0; tmp<myFlying.Length; tmp++)
            {
                if (myFlying[tmp].timeArrival != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    string[] arrSum = {
                            (tmp+1).ToString().PadLeft(3),
                            myFlying[tmp].timeArrival.PadLeft(20),
                            myFlying[tmp].timeDeparture.PadLeft(20),
                            myFlying[tmp].flightNumber.PadLeft(20),
                            myFlying[tmp].cityOfArrival.PadLeft(20),
                            myFlying[tmp].cityOfDeparture.ToString().PadLeft(20),
                            myFlying[tmp].airLines.PadLeft(20),
                            myFlying[tmp].terminal.PadLeft(20),
                            myFlying[tmp].flyingStatus.ToString().PadLeft(20),
                            myFlying[tmp].gate.PadLeft(20),
                            };
                    Console.WriteLine(string.Join("|", arrSum));
                    Console.ResetColor();
                    showTableBoard();
                }
                else
                {
                    strTmp = "---";
                    string[] arrSum = { (tmp+1).ToString().PadLeft(3),
                            strTmp.PadLeft(20), strTmp.PadLeft(20),
                            strTmp.PadLeft(20), strTmp.PadLeft(20),
                            strTmp.PadLeft(20), strTmp.PadLeft(20),
                            strTmp.PadLeft(20), strTmp.PadLeft(20),
                            strTmp.PadLeft(20)};
                    Console.WriteLine(string.Join("|", arrSum));
                    showTableBoard();
                    Console.ResetColor();
                }
            }           
        }

        public static void showMainHat()
        {            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string arrival = "AIRPORT KYIV";           
            string[] colums = { arrival.PadLeft(15), DateTime.Now.ToString().PadLeft(175) };
            string delim = new string('-',195);
            Console.WriteLine(delim);
            Console.WriteLine(string.Join("",colums));
            Console.WriteLine(delim);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.ResetColor();
        }
        public static void showTableHat()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string[] colums = { "№".PadLeft(3),
                "Arrival time".PadLeft(20), "Departure time".PadLeft(20),
                "Flight number".PadLeft(20), "Arrival".PadLeft(20),
                "Departure".PadLeft(20), "Airline".PadLeft(20),
                "Terminal".PadLeft(20), "Status".PadLeft(20),
                "Gate".PadLeft(20)};

            string delim = new string('-', 195);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(delim);
            Console.WriteLine(string.Join("|", colums));
            Console.WriteLine(delim);
            Console.ResetColor();
        }
        public static void showTableBoard()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string delim = new string('*', 195);
            Console.WriteLine(delim);
            Console.ResetColor();
        }
    
        public static void editFly (int numberEdit)
        {
            if(myFlying[numberEdit].timeDeparture != null)
            {
                Console.WriteLine("Enter time departure:");
                myFlying[numberEdit].timeDeparture = Console.ReadLine();

                Console.WriteLine("Enter time arrival:");
                myFlying[numberEdit].timeArrival = Console.ReadLine();

                Console.WriteLine("Enter flight number:");
                myFlying[numberEdit].flightNumber = Console.ReadLine();

                Console.WriteLine("Enter city of arrival:");
                myFlying[numberEdit].cityOfArrival = Console.ReadLine();

                Console.WriteLine("Enter city of departure:");
                myFlying[numberEdit].cityOfDeparture = Console.ReadLine();

                Console.WriteLine("Enter airlines:");
                myFlying[numberEdit].airLines = Console.ReadLine();

                Console.WriteLine("Enter terminal:");
                myFlying[numberEdit].terminal = Console.ReadLine();

                Console.WriteLine("Enter flight status:" +
                    "\r\n\tCheck in: 1" +
                    "\r\n\tGate closed: 2" +
                    "\r\n\tArrived: 3" +
                    "\r\n\tDeparted at: 4" +
                    "\r\n\tUnknown: 5" +
                    "\r\n\tCanseled: 6" +
                    "\r\n\tExpected at: 7" +
                    "\r\n\tDelayed: 8" +
                    "\r\n\tIn_flight: 9");
                int tmp = int.Parse(Console.ReadLine());
                Status num = (Status)tmp;
                switch (num)
                {
                    case Status.Check_in: myFlying[numberEdit].flyingStatus = Status.Check_in; break;
                    case Status.Gate_Closed: myFlying[numberEdit].flyingStatus = Status.Gate_Closed; break;
                    case Status.Arrived: myFlying[numberEdit].flyingStatus = Status.Arrived; break;
                    case Status.Departed_at: myFlying[numberEdit].flyingStatus = Status.Departed_at; break;
                    case Status.Unknown: myFlying[numberEdit].flyingStatus = Status.Unknown; break;
                    case Status.Canseled: myFlying[numberEdit].flyingStatus = Status.Canseled; break;
                    case Status.Expected_at: myFlying[numberEdit].flyingStatus = Status.Expected_at; break;
                    case Status.Delayed: myFlying[numberEdit].flyingStatus = Status.Delayed; break;
                    case Status.In_flight: myFlying[numberEdit].flyingStatus = Status.In_flight; break;
                }
                Console.WriteLine("Gate:");
                myFlying[numberEdit].gate = Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong choise!!!" +
                    "\r\nWAIT A FEW SECONDS!!!");
                Console.ResetColor();
                Thread.Sleep(5000);
            }

        }
    }
}
