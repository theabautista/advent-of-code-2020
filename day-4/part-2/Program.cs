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
                        
                        // see if values are valid for appropriate field
                        switch (separated_key_val_pair[0])
                        {
                        case "byr":
                        
                            if (separated_key_val_pair[1].Length == 4)
                            {
                                bool isNumeric = int.TryParse(separated_key_val_pair[1], out int n);
                                success = (isNumeric && int.Parse(separated_key_val_pair[1]) >= 1920 && int.Parse(separated_key_val_pair[1]) <=2002) ? true : false;
                            }
                            break;
                        case "iyr":
                        
                            if (separated_key_val_pair[1].Length == 4)
                            {
                                bool isNumeric = int.TryParse(separated_key_val_pair[1], out int n);
                                success = (separated_key_val_pair[1].Length == 4 && int.Parse(separated_key_val_pair[1]) >= 2010 && int.Parse(separated_key_val_pair[1]) <=2020) ? true : false;
                            }
                            break;
                        case "eyr":
                        
                            if (separated_key_val_pair[1].Length == 4)
                            {
                                bool isNumeric = int.TryParse(separated_key_val_pair[1], out int n);
                                success = (separated_key_val_pair[1].Length == 4 && int.Parse(separated_key_val_pair[1]) >= 2020 && int.Parse(separated_key_val_pair[1]) <=2030) ? true : false;
                            }
                            break;
                        case "hgt":
                        
                            string unit = separated_key_val_pair[1].Substring(separated_key_val_pair[1].Length-2);
                            if (unit == "cm")
                            {
                                var isNumeric = int.TryParse(separated_key_val_pair[1].Substring(0,3), out int n);
                                success = (isNumeric && int.Parse(separated_key_val_pair[1].Substring(0,3)) >= 150 && int.Parse(separated_key_val_pair[1].Substring(0,3)) <= 193) ? true : false;
                            } else if (unit == "in")
                            {
                                var isNumeric = int.TryParse(separated_key_val_pair[1].Substring(0,2), out int n);
                                success = (isNumeric && int.Parse(separated_key_val_pair[1].Substring(0,2)) >= 59 && int.Parse(separated_key_val_pair[1].Substring(0,2)) <= 76) ? true : false;
                            }
                            break;
                        case "hcl":
                        
                            if (separated_key_val_pair[1].Length == 7 && separated_key_val_pair[1][0] == '#')
                            {
                                bool validLetter = true;
                                for (int i = 1; i < separated_key_val_pair[1].Length; i++)
                                {
                                    if ((!Char.IsDigit(separated_key_val_pair[1][i])) && (!"abcdef".Contains(separated_key_val_pair[1][i])))
                                    {
                                        validLetter = false;
                                        break;
                                    }
                                }
                                success = validLetter;
                            }
                            break;
                        case "ecl":
                        
                            string[] validECL = new string[] {"amb","blu","brn","gry","grn","hzl","oth"};
                            success = Array.Exists(validECL, ecl => ecl.Contains(separated_key_val_pair[1]));
                            break;
                        case "pid":
                            if (separated_key_val_pair[1].Length == 9)
                            {
                            success = int.TryParse(separated_key_val_pair[1], out int n);
                            }
                            break;
                        }
                        
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
