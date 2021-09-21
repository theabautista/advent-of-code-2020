using System;
using System.IO;

namespace part_1
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

        static void Main(string[] args)
        {
            StreamReader file = new StreamReader(args[0]);
            
            double highest_seat_ID = 0;

            string line;
            while ((line = file.ReadLine()) != null)
            {
                double row = FindRow(line.Substring(0,7),0,0,127);
                double col = FindColumn(line[^3..],0,0,7);

                double seat_ID = (row * 8) + col;
                highest_seat_ID = seat_ID > highest_seat_ID ? seat_ID : highest_seat_ID;
            }
            Console.WriteLine($"Highest seat ID is {highest_seat_ID}");
        }
    }
}