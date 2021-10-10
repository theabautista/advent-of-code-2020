using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // load whole file as a string
            string whole_file_string = File.ReadAllText(args[0]);

            string[] boarding_groups = whole_file_string.Split(new string[] { Environment.NewLine + Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
            
            Console.WriteLine($"Number of groups: {boarding_groups.Length}");

            List<int> count_per_group = new List<int>();
            foreach (string group in boarding_groups)
            {
                int group_size = group.Contains('\n') ? group.Count(f => f == '\n')+1 : 1;

                // check for number of occurences for each unique char
                string unique_questions = new String(group.Replace("\n","").Distinct().ToArray());
                
                int questions_answered = 0;
                foreach (char question in unique_questions)
                {
                     int question_occurence = group.Split(question).Length - 1;
                     questions_answered = (question_occurence == group_size) ? questions_answered + 1 : questions_answered;
                }

                count_per_group.Add(questions_answered);
            }

            Console.WriteLine($"Number of checked groups: {count_per_group.Count}");
            Console.WriteLine($"Answer: {count_per_group.Sum()}");
        }
    }
}
