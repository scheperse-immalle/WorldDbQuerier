using System;
using MySql.Data.MySqlClient;

namespace WorldDbQuerier
{
    class Program
    {
        static string versionNumber = "0.1";
        static string versionNumber1 = "0.2";
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


            }
            else
            {
                Console.WriteLine("???");
            }

            MySqlConnection comm = new MySqlConnection();


            comm.ConnectionString = "Server = 192.168.56.102;Port = 3306; Database = concerten;Uid = root;Pwd = r00t; ";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = comm;
            cmd.CommandText = "SELECT count(*) FROM world.Country";

            comm.Open();

            Console.WriteLine("Version {0} ; ", versionNumber1);
            Console.WriteLine("Aantal landen {0}", cmd.ExecuteScalar());





        }
    }
}
