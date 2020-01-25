using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var nums = new[] { 2, 5, 1, 9, 22, -1 };
            //for(int i=0;i<nums.Length;i++)
            //for (int j = 0; j < nums.Length-1; j++)
            //{
            //    if(nums[j]> nums[j+1])
            //        {
            //            int tmp = nums[j];
            //            nums[j] = nums[j + 1];
            //            nums[j + 1] = tmp;
            //        }
            //}

            //var items = new int[5] { 5,4,3,2,1 };
            //var lastItem = items[^1];
            //enum Color : int //int default
            //{
            //    Red,
            //    Green,
            //    Blue
            //}
            ////Color c = Color.Blue;  //c=2
            //Enum c = Color.Red;
            //Color = (Color)c;
            //Color blank2 = Enum.Parse<Color>(colorStr);
            //[Flags]
            //enum Color //int default
            //{
            //    Red,
            //    Green,
            //    Blue
            //}
            //Color favoriteColors = Color.Blue | Color.Green; //return blue and green

            //bool isYellowSelected = favoriteColor.HasFlag(Color.Yellow); 
            //user u = new user();
            //user u2;
            //u2.age = 30;
            //u2.name = "Taras";

            //u.age = 12;
            //u.name = "Ihor";

            //struct user
            //{
            //    public string name;
            //    public int age;
            //}

            //user u = new user();
            //object o = u; //упаковка
            //user unboxed = (user) o; //розпаковка
            [StructLayout(LayoutKind.Explicit)]
            struct Color
            {
                [FieldOffset(0)]
                public uint Value;
                [FieldOffset(0)]
                public byte Red;
                [FieldOffset(1)]
                public byte Green;
                [FieldOffset(2)]
                public byte Blue;
                [FieldOffset(3)]
                public byte Alpha;
            }
            
            
        }
    }
}
