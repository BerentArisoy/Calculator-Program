using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator //Metin Berent Arisoy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Convert("59", 10, 2));
            Console.WriteLine(Convert("101", 2, 10));
            Console.WriteLine(Convert("101001011101", 2, 16));
            Console.WriteLine(Convert("72312", 8, 8));
            Console.WriteLine(Convert("92312", 8, 8));
            Console.WriteLine(Convert("0xA", 10, 8));

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }

        static string Convert(string rep, int sb, int db)
        {
            try {

                if (sb < 2 || sb > 16 || db < 2 || db > 16)
                {
                    throw new ArgumentException("Source and destination bases must be between 2 and 16.");
                }

                string digits = "0123456789ABCDEF";

                if (rep.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Error (source base ambiguous)");
                }
                else if (rep.StartsWith("0b", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Error (source base ambiguous)");
                }
                else if (rep.StartsWith("0", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Error (source base ambiguous)");
                }

                int value = 0;

                int position;

                string result = "";

                for (int i = 0; i < rep.Length; i++)
                {
                    position = digits.IndexOf(rep[i]);

                    if (position == -1 || position >= sb)
                    {
                        throw new ArgumentException("Unrecognized digit.");
                    }

                    value = value * sb + position;
                }

                while (value > 0)
                {
                    int rem = value % db;  // Find the char in digits that corresponds to the remainder

                    result = digits[rem] + result;

                    value = value / db;
                }
                return "Conversion result: " + result;

            }
            catch (ArgumentException ex)
            {
                return  "Error: " + ex.Message;
            }
        }

    }

}
