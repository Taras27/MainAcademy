using System;
using System.Threading;
using System.Globalization;

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
            public DateTime timeArrival; //
            public DateTime timeDeparture; //
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
                    "\r\n\tSearch fligt: 4" +
                    "\r\n\tSearch fligt hour: 5");
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

                        for(int i=0; i<myFlying.Length; i++)
                        {
                            showFly(i);
                        }

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
                        Console.WriteLine("Choise pametr for search:" +
                            "\r\n\tSearch by flight number: 1" +
                            "\r\n\tSearch by time of arrival: 2" +
                            "\r\n\tSearch by arrival city: 3" +
                            "\r\n\tSearch by departure city: 4");
                        int tmp = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter your key for search:");
                        string keySearch = Console.ReadLine();

                        searchFly(keySearch, tmp);

                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;

                    case 5://one hour
                        Console.Clear();
                        Console.WriteLine("Search of the flight which is the nearest!");
                        Console.WriteLine("Enter time value in format: dd.mm.yyyy hh:mm:ss :");
                        DateTime tmpDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter port:");
                        string port = Console.ReadLine();
                        Console.WriteLine("Enter digit to choise port:" +
                            "\r\n\t In arrival: 1" +
                            "\r\n\t In departure: 2");
                        int choiseParam = int.Parse(Console.ReadLine());

                        sortFly(tmpDate, port, choiseParam);

                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static void addFly(int numFly)
        {
            Console.WriteLine("Enter time departure in format dd.mm.yyyy hh:mm:ss:");
            myFlying[numFly].timeDeparture = DateTime.Parse (Console.ReadLine());

            Console.WriteLine("Enter time arrival in format dd.mm.yyyy hh:mm:ss:");
            myFlying[numFly].timeArrival = DateTime.Parse(Console.ReadLine());

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

        public static void showFly(int num)
        {            
            string strTmp = null;
            
                if (myFlying[num].flightNumber != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    string[] arrSum = {
                            (num+1).ToString().PadLeft(3),
                            myFlying[num].timeArrival.ToString().PadLeft(20),
                            myFlying[num].timeDeparture.ToString().PadLeft(20),
                            myFlying[num].flightNumber.PadLeft(20),
                            myFlying[num].cityOfArrival.PadLeft(20),
                            myFlying[num].cityOfDeparture.ToString().PadLeft(20),
                            myFlying[num].airLines.PadLeft(20),
                            myFlying[num].terminal.PadLeft(20),
                            myFlying[num].flyingStatus.ToString().PadLeft(20),
                            myFlying[num].gate.PadLeft(20),
                            };
                    Console.WriteLine(string.Join("|", arrSum));
                    Console.ResetColor();
                    showTableBoard();
                }
                else
                {
                    strTmp = "---";
                    string[] arrSum = { (num+1).ToString().PadLeft(3),
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
            if(myFlying[numberEdit].flightNumber != null)
            {
                Console.WriteLine("Enter time departure in format dd.mm.yyyy hh:mm:ss:");
                myFlying[numberEdit].timeDeparture = DateTime.Parse (Console.ReadLine());

                Console.WriteLine("Enter time arrival in format dd.mm.yyyy hh:mm:ss:");
                myFlying[numberEdit].timeArrival = DateTime.Parse(Console.ReadLine());

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
    
        public static void searchFly(string key, int param )
        {
            showMainHat();
            showTableHat();
            switch (param)
            {
                case 1: //flight number
                    for(int i=0;i<myFlying.Length; i++)
                    {
                        if(myFlying[i].flightNumber == key)
                        {
                            showFly(i);                           
                        }
                    }
                    break;

                case 2: //time of arrival
                    for (int i = 0; i < myFlying.Length; i++)
                    {
                        if (myFlying[i].timeArrival.ToString() == key)
                        {
                            showFly(i);                            
                        }
                    }
                    break;

                case 3: //arrival port
                    for (int i = 0; i < myFlying.Length; i++)
                    {
                        if (myFlying[i].cityOfArrival == key)
                        {
                            showFly(i);                            
                        }
                    }
                    break;

                case 4: // departure port
                    for (int i = 0; i < myFlying.Length; i++)
                    {
                        if (myFlying[i].cityOfDeparture == key)
                        {
                            showFly(i);                            
                        }
                    }
                    break;
            }
        }

        public static void sortFly(DateTime keyValueTime, string port, int choise)
        {
            Console.Clear();
            showMainHat();
            showTableHat();

            flyingInfo[] myFlyingTmp = new flyingInfo[20];
            flyingInfo[] myFlyingOne = new flyingInfo[1];

            int counter = 0;
            for (int i = 0; i < myFlyingTmp.Length; i++)
            {
                TimeSpan diferenceTime = TimeSpan.Zero;
                if (choise == 1)
                {
                    diferenceTime = myFlying[i].timeArrival - keyValueTime;
                }
                if (choise == 2)
                {
                    diferenceTime = myFlying[i].timeDeparture - keyValueTime;
                }
                if (diferenceTime.Minutes <= 59 && diferenceTime.Hours < 1
                    && diferenceTime.Minutes >= 0 && diferenceTime.Hours >= 0)
                {
                    myFlyingTmp[counter] = myFlying[i];
                    counter++;
                }
            }

            flyingInfo[] myFlyingTwo = new flyingInfo[20];
            if (choise == 1)  //to city arrival
            {
                for (int i = 0; i < myFlyingTmp.Length; i++)
                {
                    if (myFlyingTmp[i].cityOfArrival == port)
                    {
                        myFlyingTwo[i] = myFlyingTmp[i];
                    }
                }
            }
            if (choise == 2) // from city departure
            {
                for (int i = 0; i < myFlyingTmp.Length; i++)
                {
                    if (myFlyingTmp[i].cityOfDeparture == port)
                    {
                        myFlyingTwo[i] = myFlyingTmp[i];
                    }
                }
            }           

            for (int i = 0; i < myFlyingTwo.Length - 1; i++)
            {
                for (int j = i + 1; j < myFlyingTwo.Length; j++)
                {
                    if (choise == 1)
                    {
                        if (myFlyingTwo[i].timeArrival > myFlyingTwo[j].timeArrival)
                        {
                            myFlyingOne[0] = myFlyingTwo[i];
                            myFlyingTwo[i] = myFlyingTwo[j];
                            myFlyingTwo[j] = myFlyingOne[0];
                        }
                    }
                    if (choise == 2)
                    {
                        if (myFlyingTwo[i].timeDeparture > myFlyingTwo[j].timeDeparture)
                        {
                            myFlyingOne[0] = myFlyingTwo[i];
                            myFlyingTwo[i] = myFlyingTwo[j];
                            myFlyingTwo[j] = myFlyingOne[0];
                        }
                    }
                }
            }
            int count = 0;
            for(int i = 0; i< myFlyingTwo.Length; i++)
            {
                if (myFlyingTwo[i].flightNumber != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    string[] arrSum = {
                            (++count).ToString().PadLeft(3),
                            myFlyingTwo[i].timeArrival.ToString().PadLeft(20),
                            myFlyingTwo[i].timeDeparture.ToString().PadLeft(20),
                            myFlyingTwo[i].flightNumber.PadLeft(20),
                            myFlyingTwo[i].cityOfArrival.PadLeft(20),
                            myFlyingTwo[i].cityOfDeparture.ToString().PadLeft(20),
                            myFlyingTwo[i].airLines.PadLeft(20),
                            myFlyingTwo[i].terminal.PadLeft(20),
                            myFlyingTwo[i].flyingStatus.ToString().PadLeft(20),
                            myFlyingTwo[i].gate.PadLeft(20),
                            };
                    Console.WriteLine(string.Join("|", arrSum));
                    Console.ResetColor();
                    showTableBoard();
                }
            }
            
        }
    }
}
