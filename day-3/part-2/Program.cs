using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace part_1
{
    class Program
    {
        // public static List<int> indices = new List<int>(); // this var must be static in order to use it in Main
        public static void Main(string[] args)
        {   
            checked
            {

            
            // global var
            List<uint> tree_crash_array = new List<uint>();
            int[,] traverse = new int[,] { {1,1},{3,1},{5,1},{7,1},{1,2} };
            
            // creating instance of streamreader to read from a file
            StreamReader file = new StreamReader(args[0]);

            // read entire file into a string
            string[] lines = File.ReadAllLines(args[0]);
            
            // for each path in transverse
            for (int i = 0; i < traverse.GetLength(0); i++)
            {
                int current_position = 0;
                uint tree_crash = 0;
                for (int n=traverse[i,1]; n<lines.GetLength(0); n+=n=traverse[i,1])  // reads each line of file one at a time, skipping the first line
                {   
                    // update position (to the right)
                    current_position += traverse[i,0];
                    
                    // check if there is a tree in current position
                    if (lines[n][current_position%lines[n].Length]=='#')
                    {
                        tree_crash++;
                    }
                }
                if (tree_crash != 0) {tree_crash_array.Add(tree_crash);}
            }
            
            uint prod = 1;
            foreach (int value in tree_crash_array)
            {
                prod *= value;
            }
            Console.WriteLine($"Product of trees encountered: {prod}");
            }
        }
        
    }

}

