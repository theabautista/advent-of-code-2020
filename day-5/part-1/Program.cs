using System;
using System.IO;

namespace part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader(args[0]);
            
            double highest_seat_ID = 0;

            string line;
            while ((line = file.ReadLine()) != null){

                double left_ptr = 0;
                double right_ptr = 7;

                double front_ptr = 127;
                double back_ptr = 0;

                double row, col;

                for (int i = 0; i < line.Length; i++)
                {
                   if (i < 7)
                   {
                        switch (line[i])
                        {
                            case 'F':
                                front_ptr -= Math.Ceiling((front_ptr - back_ptr) / 2.0);
                                break;
                            case 'B':
                                back_ptr += Math.Ceiling((front_ptr - back_ptr) / 2.0);
                                break;
                        }
                   } else
                   {
                        switch (line[i])
                        {
                            case 'R':
                                left_ptr += Math.Ceiling((right_ptr - left_ptr) / 2.0);
                                break;
                            case 'L':
                                right_ptr -= Math.Ceiling((right_ptr - left_ptr) / 2.0);
                                break;
                        }
                   }
                } 
                row = front_ptr;
                col = right_ptr;

                double seat_ID = (row * 8) + col;
                highest_seat_ID = seat_ID > highest_seat_ID ? seat_ID : highest_seat_ID;
            }
            Console.WriteLine($"Highest seat ID is {highest_seat_ID}");
        }
    }
}
