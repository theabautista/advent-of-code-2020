using System;
using System.Collections.Generic;
using System.IO;


namespace part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader(args[0]);

            Dictionary<string,string> passport = new Dictionary<string,string>();
            uint count = 0;
            uint numfiles = 0;
            string line;

            while ((line = file.ReadLine()) != null)
            {
                if (line != "")
                {
                    string[] parsed_string = new string[] {line};
                    
                    // parse line by separating via colons and spaces
                    if (line.Contains(" "))
                    {
                        parsed_string = line.Split(" ");
                    }
                    
                    foreach (string key_val_pair in parsed_string)
                    {
                        string[] separated_key_val_pair = key_val_pair.Split(":");
                        if (!passport.ContainsKey(separated_key_val_pair[0]))
                        {
                            passport.Add(separated_key_val_pair[0],separated_key_val_pair[1]);
                        }
                    }
                } else
                {
                    numfiles++;
                    // check if passport is valid
                    if (passport.ContainsKey("byr") && passport.ContainsKey("iyr") && passport.ContainsKey("eyr") && passport.ContainsKey("hgt") && passport.ContainsKey("hcl") && passport.ContainsKey("ecl") && passport.ContainsKey("pid"))
                    {
                        count++;
                    }
                    passport.Clear();
                }
            }

            if (passport.Count != 0)
            {   
                numfiles++;
                // check if passport is valid
                if (passport.ContainsKey("byr") && passport.ContainsKey("iyr") && passport.ContainsKey("eyr") && passport.ContainsKey("hgt") && passport.ContainsKey("hcl") && passport.ContainsKey("ecl") && passport.ContainsKey("pid"))
                {
                    count++;
                }
            }

            Console.WriteLine($"Total number of files: {numfiles}");
            Console.WriteLine($"Number of valid passports: {count}");
            
        }
    }
}
