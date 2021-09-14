using System;
using System.IO;

namespace part_1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // load file
            StreamReader file = new System.IO.StreamReader(args[0]); 

            // read file line by line
            string line;
            while((line = file.ReadLine()) != null)  
            {  
                // check if boarding pass is a valid length
                 if (line.Length == 10)
                 {
                    
                 } else { continue; }
            } 

            file.Close();
        }
    }
}
