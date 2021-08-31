using System;

namespace day_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // global variables
            int num_approved_pw = 0;
            string line;

            // read file 
            System.IO.StreamReader file = new System.IO.StreamReader(args[0]); 

            // run for each line
            while((line = file.ReadLine()) != null)  // reads each line of file one at a time
            {  
                // separate line by spaces
                string[] properties = line.Split(' '); 

                // separate first string in properties array to get number of times char must appear in password
                string[] idx_required = properties[0].Split('-');  
                int min_idx = Convert.ToInt16(idx_required[0]);
                int max_idx = Convert.ToInt16(idx_required[1]);

                // check required positions are within size of password given
                if (min_idx < properties[2].Length && max_idx <= properties[2].Length)
                {
                num_approved_pw = properties[2][min_idx-1] == properties[1][0] ^ properties[2][max_idx-1] == properties[1][0] ? num_approved_pw+1 : num_approved_pw;
                }

            }   
           
            file.Close();
            Console.WriteLine($"Number of valid passwords: {num_approved_pw}"); 
        }
    }
}
