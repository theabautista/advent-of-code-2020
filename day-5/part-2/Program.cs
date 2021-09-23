using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace part_2
{
    class Program
    {
        static double FindRow(string boarding_pass_subset,int row_idx, double min_value, double max_value)
        {
            if (min_value != max_value)
            {
                switch (boarding_pass_subset[row_idx])
                {
                    case 'F':
                        max_value -= Math.Ceiling((max_value - min_value) / 2.0);
                        break;
                    case 'B':
                        min_value += Math.Ceiling((max_value - min_value) / 2.0);
                        break;
                }
                return FindRow(boarding_pass_subset,row_idx+1,min_value,max_value);
            }
            return min_value;
        }

        public static double FindColumn(string boarding_pass_subset,int row_idx, double min_value, double max_value)
        {
            if (min_value != max_value)
            {
                switch (boarding_pass_subset[row_idx])
                {
                    case 'L':
                        max_value -= Math.Ceiling((max_value - min_value) / 2.0);
                        break;
                    case 'R':
                        min_value += Math.Ceiling((max_value - min_value) / 2.0);
                        break;
                }
                return FindColumn(boarding_pass_subset,row_idx+1,min_value,max_value);
            }
            return min_value;
        }

        static List<double> SuccessiveDifference(List<double> list_array)
        {
            List<double> differences = new List<double>();
            return differences;
        }

        static void Main(string[] args)
        {
            StreamReader file = new StreamReader(args[0]);
            List<int> seat_ID = new List<int>();

            string line;
            while ((line = file.ReadLine()) != null)
            {
                var row = Convert.ToInt32(FindRow(line.Substring(0,7),0,0,127));
                var column = Convert.ToInt32(FindColumn(line[^3..],0,0,7));

                seat_ID.Add((row*8)+column);

            }
            var missing_seat_ID = Enumerable.Range(Convert.ToInt32(seat_ID.Min()),seat_ID.Distinct().Count()).Except(seat_ID);
            var my_seat_ID = missing_seat_ID.ToList();
            Console.WriteLine($"My seat ID is {my_seat_ID[0]}");
        }
    }
}