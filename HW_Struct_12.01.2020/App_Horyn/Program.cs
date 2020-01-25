using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Horyn
{
    class Program
    {
        enum GroupPeople
        {
            empty,
            work,
            friend,
            familiar,
            family
        }
        struct contact
        {
            public string name;
            public string phoneNumber;
            public string email;
            public string note;
            public GroupPeople myGroup;
            public string manAdress;
            public string[] arrayHoby; 
        }

        static contact[] myPerson = new contact[20];
        public static int personCount = 0;
        static void Main(string[] args)
        {
            while (true)
            {
                if (personCount < 20)
                {
                   Console.Clear();
                   Console.WriteLine("Choise function:" +
                        "\r\n\tAdd contact press: 1" +
                        "\r\n\tDelete contact press: 2" +
                        "\r\n\tSearch contact press: 3" +
                        "\r\n\tShow contact press: 4");
                    int userChoise = int.Parse(Console.ReadLine());
                    if (userChoise > 0 && userChoise < 5)
                    {
                        switch (userChoise)
                        {
                            case 1:
                                Console.Clear();                                
                                addPerson(personCount);
                                personCount++;
                                Console.WriteLine("Press any key to continue!!!");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Choice number to delete person:" +
                                    "from 1 to 20");
                                int userInput = int.Parse(Console.ReadLine());
                                deletePerson(userInput-1);

                                showTableHat();

                                for (int i=0; i < 20; i++ )
                                {                                   
                                    showPerson(i);
                                    showTableBoard();
                                }
                                Console.WriteLine("Press any key to continue!!!");
                                Console.ReadKey();
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Choise parametr of searh:" +
                                    "\r\n\tSearch by phone number: 1" +
                                    "\r\n\tSearch by hobby: 2" +
                                    "\r\n\tSearch by name: 3" +
                                    "\r\n\tSearch by group: 4");

                                int paramSearch = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter your key for search:");
                                string keySearch = Console.ReadLine();

                                searchPerson(paramSearch, keySearch);

                                Console.WriteLine("Press any key to continue!!!");
                                Console.ReadKey();
                                break;
                            case 4:
                                Console.Clear();
                                showTableHat();

                                for (int i = 0; i < 20; i++)
                                {
                                    showPerson(i);
                                    showTableBoard();
                                }
                                Console.WriteLine("Press any key to continue!!!");
                                Console.ReadKey();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Out of range!!!");
                    }                    
                }
                else
                {
                    break;
                }
            }
        }
        public static void addPerson(int numPerson)
        {            
            Console.WriteLine("Enter contact name:");
            myPerson[numPerson].name = Console.ReadLine();
            Console.WriteLine("Enter contact phone number:");
            Console.WriteLine("FORMAT: +38(XXX)XXXXXXX");
            myPerson[numPerson].phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter contact e-mail:");
            myPerson[numPerson].email = Console.ReadLine();
            Console.WriteLine("Enter contact note:");
            myPerson[numPerson].note = Console.ReadLine();
            Console.WriteLine("Enter contact group:" +
                "\r\n\tWork group: 1" +
                "\r\n\tFriend group: 2" +
                "\r\n\tFamiliar group: 3" +
                "\r\n\tFamily group: 4");
            int tmp = int.Parse(Console.ReadLine());
            GroupPeople num = (GroupPeople) tmp;
            switch (num)
            {
                case GroupPeople.work:
                    myPerson[numPerson].myGroup = GroupPeople.work;
                    break;

                case GroupPeople.friend:
                    myPerson[numPerson].myGroup = GroupPeople.friend;
                    break;

                case GroupPeople.familiar:
                    myPerson[numPerson].myGroup = GroupPeople.familiar;
                    break;

                case GroupPeople.family:
                    myPerson[numPerson].myGroup = GroupPeople.family;
                    break;
            }
            Console.WriteLine("Enter contact adress:");
            myPerson[numPerson].manAdress = Console.ReadLine();

            Console.WriteLine("Enter contact hobby!");
            myPerson[numPerson].arrayHoby = new string[5];
            Console.Write("Array hobby lenght: {0} \r\n", myPerson[numPerson].arrayHoby.Length);

            for (int i=0;i< myPerson[numPerson].arrayHoby.Length; i++)
            {
                Console.WriteLine("Enter contact hobby number {0}:\t",i+1);
                myPerson[numPerson].arrayHoby[i] = Console.ReadLine();
            }
            
        }
        public static void deletePerson(int numPerson)
        {
            myPerson[numPerson].name = null;
            myPerson[numPerson].phoneNumber = null;            
            myPerson[numPerson].email = null;            
            myPerson[numPerson].note = null;
            myPerson[numPerson].myGroup = GroupPeople.empty;           
            myPerson[numPerson].manAdress = null;
            myPerson[numPerson].arrayHoby = new string[5];
            for (int i = 0; i < myPerson[numPerson].arrayHoby.Length; i++)
            {          
                myPerson[numPerson].arrayHoby[i] = null;
            }
        }
        public static void searchPerson(int paramSeach, string key)
        {
            showTableHat();

            switch (paramSeach)
            {
                case 1: //номер телефону                    
                    for(int i=0; i < 20; i++)
                    {
                        if(myPerson[i].phoneNumber == key)
                        {
                            showPerson(i);
                            showTableBoard();
                        }                       
                    }
                    break;

                case 2: //Хоббі
                    for (int i = 0; i < 20; i++)
                    {
                        if (myPerson[i].arrayHoby != null)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (myPerson[i].arrayHoby[j] != null)
                                {
                                    showPerson(i);
                                    showTableBoard();
                                }                                
                            }
                        }
                    }
                    break;

                case 3: //Ім'я
                    for (int i = 0; i < 20; i++)
                    {
                        if (myPerson[i].name == key)
                        {
                            showPerson(i);
                            showTableBoard();
                        }
                    }
                    break;

                case 4: //Тип
                    for (int i = 0; i < 20; i++)
                    {
                        if (myPerson[i].myGroup.ToString() == key)
                        {
                            showPerson(i);
                            showTableBoard();
                        }
                    }
                    break;
            }                    
        }
        public static void showPerson(int tmp)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string strTmp = null;            
            if (myPerson[tmp].name != null)
            {
                for (int i = 0; i < myPerson[tmp].arrayHoby.Length; i++)
                {
                    strTmp += myPerson[tmp].arrayHoby[i] + ", ";
                }
                string[] arrSum = { (tmp+1).ToString().PadLeft(3),
                myPerson[tmp].name.PadLeft(20),
                myPerson[tmp].phoneNumber.PadLeft(20),
                myPerson[tmp].email.PadLeft(20),
                myPerson[tmp].note.PadLeft(20),
                myPerson[tmp].myGroup.ToString().PadLeft(20),
                myPerson[tmp].manAdress.PadLeft(20),
                strTmp.PadLeft(40)  };
                Console.WriteLine(string.Join("|", arrSum));
                Console.ResetColor();
            }
            else
            {
                strTmp = "---";
                string[] arrSum = { (tmp+1).ToString().PadLeft(3),
                "---".PadLeft(20), "---".PadLeft(20),
                "---".PadLeft(20),"---".PadLeft(20),
                "---".PadLeft(20),"---".PadLeft(20),
                strTmp.PadLeft(20)  };
                Console.WriteLine(string.Join("|", arrSum));
                Console.ResetColor();
            }
        }

        public static void showTableHat()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string[] colums = { "№".PadLeft(3), 
                "Name".PadLeft(20), "Phone number".PadLeft(20),
                "Email".PadLeft(20), "Note".PadLeft(20),
                "Group".PadLeft(20), "Adress".PadLeft(20),
                "Hobby".PadLeft(40) };

            string delim = new string('*', 200);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(delim);
            Console.WriteLine(string.Join("|", colums));
            Console.WriteLine(delim);
            Console.ResetColor();
        }

        public static void showTableBoard() 
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string delim = new string('*', 200);
            Console.WriteLine(delim);
            Console.ResetColor();
        }

    }
}
