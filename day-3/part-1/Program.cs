using System;
using System.Collections.Generic;
using System.IO;


namespace part_1
{
    class Program
    {
        // public static List<int> indices = new List<int>(); // this var must be static in order to use it in Main
        public static void Main(string[] args)
        {   
            // global var
            int tree_crash = 0;
            string line;

            // creating instance of streamreader to read from a file
            StreamReader file = new StreamReader(args[0]);
            
            // read file line by line starting from the second one
            int current_position = 0;
            int current_line = 1;
            while ((line = file.ReadLine()) != null)  // reads each line of file one at a time, skipping the first line
            {
                if (current_line == 1) // skips first line of file
                {
                    current_line += 1;
                    continue;
                }
                // update position
                current_position += 3;
                
                // check if there is a tree in current position
                if (line[current_position%line.Length]=='#')
                {
                    tree_crash++;
                }
                current_line += 1;  
            }

            Console.WriteLine($"Number of trees encountered: {tree_crash}");
        }
    }
}


// wanted to make recursive function
        // public static int FindAllIndices(string comparator_string, int start_idx,int counter)
        // {
        //     if (counter < comparator_string.Length)
        //     {
        //         int idx = comparator_string.IndexOf('#',start_idx);
        //         indices.Add(idx);
        //         counter += 1;
        //          FindAllIndices(comparator_string, idx, counter);
        //     }
        //     return start_idx;
        // }
        // identify indices of trees
                // int index = 0;
                // while (index < line.LastIndexOf("#"))
                // {
                //     int idx = line.IndexOf("#", index);
                //     tree_positions.Add(idx);
                //     index = idx+1;
                // }
                // tree_positions.ForEach(p => Console.WriteLine(p));