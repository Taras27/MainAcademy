using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_1_4_lab
{

    class Program
    {
        // 1) declare enum ComputerType
        enum computerType 
        {
            Desktop,
            Laptop,
            Server
        }

        // 2) declare struct Computer
        struct Computer
        {
            public int quantityCores;
            public int coreFrequency;
            public int ramMemory;
            public int capacityHdd;
        }
        

        static void Main(string[] args)
        {
            // 3) declare jagged array of computers size 4 (4 departments)

            Computer[,][] deps = new Computer[4,3][];

            // 4) set the size of every array in jagged array (number of computers)
            deps[0, (int)computerType.Desktop] = new Computer[2];  
            deps[0, (int)computerType.Laptop] = new Computer[2];   
            deps[0, (int)computerType.Server] = new Computer[1];
          
            deps[1, (int)computerType.Laptop] = new Computer[3];

            deps[2, (int)computerType.Desktop] = new Computer[3]; 
            deps[2, (int)computerType.Laptop] = new Computer[2];

            deps[3, (int)computerType.Desktop] = new Computer[1];  
            deps[3, (int)computerType.Laptop] = new Computer[1];
            deps[3, (int)computerType.Server] = new Computer[2];

            // 5) initialize array
            // Note: use loops and if-else statements
            
            for (int i = 0; i < deps.GetLength(0); i++)
            {
                for(int j = 0; j<deps.GetLength(1); j++ )
                {   
                    if(deps[i,j] == null)
                    {
                        continue;
                    }
                    for (int k=0;k<deps[i,j].Length; k++)
                    {                       
                        computerType type = (computerType)j;
                        switch(type)
                        {
                            case computerType.Desktop:
                                deps[i, j][k].quantityCores = 4;
                                deps[i, j][k].coreFrequency = 2500;
                                deps[i, j][k].ramMemory = 6;
                                deps[i, j][k].capacityHdd = 500;
                                break;

                            case computerType.Laptop:
                                deps[i, j][k].quantityCores = 2;
                                deps[i, j][k].coreFrequency = 1700;
                                deps[i, j][k].ramMemory = 4;
                                deps[i, j][k].capacityHdd = 250;                                
                                break;

                            case computerType.Server:
                                deps[i, j][k].quantityCores = 8;
                                deps[i, j][k].coreFrequency = 3000;
                                deps[i, j][k].ramMemory = 16;
                                deps[i, j][k].capacityHdd = 2000;
                                break;
                        }
                    }
                }                
            }

            // 6) count total number of every type of computers
            int countDesktop = 0;
            int countLaptop = 0;
            int countServer = 0;
            int totalValue = 0;
            
            for (int i = 0; i < deps.GetLength(0); i++)
            {
                for (int j = 0; j < deps.GetLength(1); j++)
                {
                    if (deps[i, j] == null)
                    {
                        continue;
                    }
                    for (int k = 0; k < deps[i, j].Length; k++)
                    {
                        computerType type = (computerType)j;
                        if (type == computerType.Desktop || type == computerType.Laptop
                            || type == computerType.Server)
                        {
                            totalValue++;
                            if (type == computerType.Desktop)
                                countDesktop++;
                            else if (type == computerType.Laptop)
                                countLaptop++;
                            else if (type == computerType.Server)
                                countServer++;
                        }

                    }                           
                }
            }
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Total count of desktops is: {0}", countDesktop);
            Console.WriteLine("Total count of laptops is: {0}", countLaptop);
            Console.WriteLine("Total count of servers is: {0}", countServer);
            // 7) count total number of all computers
            Console.WriteLine("Total count of computers is: {0}", totalValue);
            // Note: use loops and if-else statements
            // Note: use the same loop for 6) and 7)



            // 8) find computer with the largest storage (HDD) - 
            // compare HHD of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements
            Console.WriteLine("-------------------------------------------------------------------");
            for (int i = 0; i < deps.GetLength(0); i++)
            {
                for (int j = 0; j < deps.GetLength(1); j++)
                {
                    if (deps[i, j] == null)
                    {
                        continue;
                    }
                    for (int k = 0; k < deps[i, j].Length; k++)
                    {
                        computerType type = (computerType)j;
                        int maxValue = deps[0, 0][0].capacityHdd;
                        if(deps[i,j][k].capacityHdd > maxValue)
                        {
                            maxValue = deps[i, j][k].capacityHdd;
                            Console.Write("Max capacity HDD is: {0} MB\n", maxValue);
                            Console.Write("Namber computer in array: {0}{1}{2}\n", i, j, k);
                        }

                    }
                }
            }

            // 9) find computer with the lowest productivity (CPU and memory) - 
            // compare CPU and memory of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements
            // Note: use logical oerators in statement conditions
            Console.WriteLine("-------------------------------------------------------------------");
            int countEntries=0;
            for (int i = 0; i < deps.GetLength(0); i++)
            {
                for (int j = 0; j < deps.GetLength(1); j++)
                {
                    if (deps[i, j] == null)
                    {
                        continue;
                    }
                    for (int k = 0; k < deps[i, j].Length; k++)
                    {
                        computerType type = (computerType)j;
                        int minFreq = deps[0, 0][0].coreFrequency;
                        int minRam = deps[0, 0][0].ramMemory;
                        int minCore = deps[0, 0][0].quantityCores;
                        
                        if (deps[i, j][k].coreFrequency < minFreq && deps[i,j][k].ramMemory < minRam
                            && deps[i, j][k].quantityCores < minCore)
                        {
                            minFreq = deps[i, j][k].coreFrequency;
                            minRam = deps[i, j][k].ramMemory;
                            minCore = deps[i, j][k].quantityCores;
                            countEntries++;
                            Console.Write(countEntries + "\tNamber computer in array: {0}{1}{2}\n", i, j, k);
                        }

                    }
                }
            }


            // 10) make desktop upgrade: change memory up to 8
            // change value of memory to 8 for every desktop. Don't do it for other computers
            // Note: use loops and if-else statements

            Console.WriteLine("-------------------------------------------------------------------");
            int countEnt = 0;
            for (int i = 0; i < deps.GetLength(0); i++)
            {
                for (int j = 0; j < deps.GetLength(1); j++)
                {
                    if (deps[i, j] == null)
                    {
                        continue;
                    }
                    for (int k = 0; k < deps[i, j].Length; k++)
                    {
                        computerType type = (computerType)j;
                        
                        if (deps[i, j][k].ramMemory == 6)
                        {
                            deps[i, j][k].ramMemory = 8;
                            
                        }
                        if(deps[i, j][k].ramMemory == 8)
                        {
                            countEnt++;
                            Console.Write(countEnt + "\tNamber computer in array: {0}{1}{2}\n", i, j, k);
                        }
                    }
                }
            }
        }
    }
}
