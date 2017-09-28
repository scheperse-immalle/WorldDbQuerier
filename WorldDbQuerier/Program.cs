using System;

namespace WorldDbQuerier
{
    class Program
    {
        static string verionNumber = "0.1";
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "-v":
                        Console.WriteLine("versie {0}", verionNumber);
                        break;
                    default:
                        Console.WriteLine("Onbekend argument");
                        break;
                }


            }
            else
            {
                Console.WriteLine("???");
            }

            
        }
    }
}
