using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab12_2
{
    class Validator
    {
        static public int ValidateIntMinMax(string message, int min, int max)
        {
            Console.Write(message);
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
            {
                Console.Write("Invalid seclection. " + message);
            }
            return choice;
        }
        static public int ValidateIntMin(string message, int min)
        {
            Console.Write(message);
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < min)
            {
                Console.Write("Invalid seclection. " + message);
            }
            return choice;
        }
        static public double ValidateDoubleMin(string message, double min)
        {
            Console.Write(message);
            double choice;
            while (!double.TryParse(Console.ReadLine(), out choice) || choice < min)
            {
                Console.Write("Invalid seclection. " + message);
            }
            return choice;
        }
        static public double ValidateDoubleMinMax(string message, double min, double max)
        {
            Console.Write(message);
            double choice;
            while (!double.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
            {
                Console.Write("Invalid seclection. " + message);
            }
            return choice;
        }

    }
}

