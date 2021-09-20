using System;
using System.IO;

namespace part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // open file
            StreamReader file = new StreamReader(args[0]);
            
            uint highest_seat_ID = 0;

            string line;
            while ((line = file.ReadLine()) != null){
                
            // instantiate base product value
            // read line by line
                // record left and right pointer positions
                // record back and front pointer positions
                // for loop for each character
                    // switch statement for back and front
                    // switch statement for left and right
                // multiply row and column
                // keep product if it is higher than the last

            
            }
            // return highest seat ID
        }
    }
}
