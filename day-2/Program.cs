using System;
using System.Linq;

namespace day_2
{
    class Program
    {
        static void Main(string[] args) // args = string of filename e.g. input.txt
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
                string[] freq_required = properties[0].Split('-');  
                int min_freq = Convert.ToInt16(freq_required[0]);
                int max_freq = Convert.ToInt16(freq_required[1]);

                // check if required char exists 
                int idx = properties[2].IndexOf(properties[1][0]);
                if (idx != -1)
                {
                    int counter = properties[2].Count(f => f == properties[1][0]);
                    num_approved_pw = (counter >= min_freq && counter <= max_freq) ? num_approved_pw + 1 : num_approved_pw;
                } 


            }   
           

            file.Close();
            Console.WriteLine($"Number of valid passwords: {num_approved_pw}"); 
        }
    }
}
