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

            Dictionary<string,string> passport = new Dictionary<string,string>();
            uint count = 0;
            uint numfiles = 0;
            string line;

            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
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
                        bool success = false;
                        string[] separated_key_val_pair = key_val_pair.Split(":");

                        bool isIntInRange(int low, int high) => int.TryParse(separated_key_val_pair[1], out int value) && value >= low && value <= high;
                        // see if values are valid for appropriate field
                        success = separated_key_val_pair[0] switch
                        {
                            "byr" => isIntInRange(1920,2002),
                            "iyr" => isIntInRange(2010,2020),
                            "eyr" => isIntInRange(2020,2030), // make these statements/tests into inline bool functions
                            "hgt" => int.TryParse(separated_key_val_pair[1][..^2], out int hgt) &&
                                        separated_key_val_pair[1][^2..] switch
                                        {
                                            "cm" => hgt >= 150 && hgt <= 193,
                                            "in" => hgt >= 59 && hgt <= 76,
                                            _ => false,
                                        },
                            "hcl" => separated_key_val_pair[1].Length == 7 && separated_key_val_pair[1][0] == '#' && separated_key_val_pair[1][1..]
                              .All(c => char.IsDigit(c) || "abcdef".Contains(c)),
                            "ecl" => new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(separated_key_val_pair[1]),
                            "pid" => separated_key_val_pair[1].Length == 9 && int.TryParse(separated_key_val_pair[1], out int n),
                            _ => false,
                        };
                        if (!passport.ContainsKey(separated_key_val_pair[0]) && success == true)
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
                        Console.WriteLine("VALID");
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

            Console.WriteLine($"Total number of passports: {numfiles}");
            Console.WriteLine($"Number of valid passports: {count}");
            
        }
    }
}
