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
            // global var
            string line;
            List<int> tree_crash_array = new List<int>();
            int[,] traverse = new int[,] { {1,1},{3,1},{5,1},{7,1},{1,2} };
            
            // creating instance of streamreader to read from a file
            StreamReader file = new StreamReader(args[0]);

            // read entire file into a string
            string[] lines = File.ReadAllLines(args[0]);
            
            // for each path in transverse
            for (int i = 0; i < traverse.GetLength(0); i++)
            {
                int current_position = 0;
                int current_line = 1;
                int tree_crash = 0;
                while ((line = file.ReadLine()) != null)  // reads each line of file one at a time, skipping the first line
                {
                    if (current_line == 1 && traverse[i,1] == 1) // skips first line of file
                    {
                        current_line += 1;
                        continue;
                    } else if (current_line == 1 && traverse[i,1] != 1 )
                    {
                        current_line += traverse[i,1];
                        continue;
                    }

                    // update position (to the right)
                    current_position += traverse[i,0];
                    
                    // check if there is a tree in current position
                    if (line[current_position%line.Length]=='#')
                    {
                        tree_crash++;
                    }
                    // update line (moving down)
                    current_line += traverse[i,1];  
                }
                if (tree_crash != 0) {tree_crash_array.Add(tree_crash);}
            }
            
            int prod = 1;
            foreach (int value in tree_crash_array)
            {
                prod *= value;
            }
            Console.WriteLine($"Product of trees encountered: {prod}");
        }
        
    }

}

