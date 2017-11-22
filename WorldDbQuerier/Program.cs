using System;
using MySql.Data.MySqlClient;

namespace WorldDbQuerier
{
    class Program
    {
        static string versionNumber = "0.1";
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "-v":
                        Console.WriteLine("versie {0}", versionNumber);
                        break;
                    default:
                        Console.WriteLine("Onbekend argument");
                        break;
                }

                string parameters;
                Console.WriteLine("1. Show all countries");
                Console.WriteLine("2. Show amount of countries");
                parameters = Console.ReadLine();

                switch (parameters)
                {

                    case "AllCountries":
                        MySqlConnection comm = new MySqlConnection();


                        comm.ConnectionString = "Server = 192.168.56.102;Port = 3306; Database = concerten;Uid = root;Pwd = r00t; ";

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = comm;
                        cmd.CommandText = "SELECT * FROM world.Country";

                        comm.Open();
                        Console.WriteLine("alle landen : {0}", cmd.ExecuteScalar());
                        break;

                    case "AmountOfCountries":
                        AmountOfCountries();
                        break;


                }
                


            }
            else
            {
                Console.WriteLine("???");
            }

            
            
        }
        public static void AmountOfCountries()
        {
            MySqlConnection comm = new MySqlConnection();


            comm.ConnectionString = "Server = 192.168.56.102;Port = 3306; Database = concerten;Uid = root;Pwd = r00t; ";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = comm;
            cmd.CommandText = "SELECT count(*) FROM world.Country";

            comm.Open();

            Console.WriteLine("Version {0} ; ", versionNumber);
            Console.WriteLine("Aantal landen {0}", cmd.ExecuteScalar());
        }
        
    }
}
