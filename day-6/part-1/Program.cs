using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader(args[0]);
            string line;
            
            List<int> count_per_group = new List<int>();
            HashSet<char> unique_questions = new HashSet<char>();

            while((line = file.ReadLine()) != null)
            {
                if (line == "")
                {
                    count_per_group.Add(unique_questions.Count);
                    unique_questions.Clear();
                    continue;
                }

                foreach (char question in line)
                {
                    unique_questions.Add(question);
                }
            }

            count_per_group.Add(unique_questions.Count);

            Console.WriteLine(count_per_group.Sum());
        }
    }
}
