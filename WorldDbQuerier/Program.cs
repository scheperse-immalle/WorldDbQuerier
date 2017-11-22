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
                Console.WriteLine("AllCoutries");
                Console.WriteLine("AmountOfCountries");
                Console.WriteLine("SearchCountry");

                parameters = Console.ReadLine();

                switch (parameters)
                {

                    case "AllCountries":
                        AllCountries();
                        break;

                    case "AmountOfCountries":
                        AmountOfCountries();
                        break;
                    case "SearchCountry":
                        SearchCountry();
                        break;


                }
            }
            
            
        }
        public static void AllCountries()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server= 192.168.56.102; port=3306; database= concerten; Uid= root; Pwd=r00t;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            conn.Open();

            cmd.CommandText = "SELECT * FROM word.Country";
            cmd.ExecuteScalar();
            

            
        }
        public static void AmountOfCountries()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server = 192.168.56.102;Port = 3306; Database = concerten;Uid = root;Pwd = r00t; ";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT count(*) FROM world.Country";

            conn.Open();

            Console.WriteLine("Version {0} ; ", versionNumber);
            Console.WriteLine("Aantal landen {0}", cmd.ExecuteScalar());
        }
        public static void SearchCountry()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=192.168.56.102; port= 3306; Database = concerten; Uid= root; pwd=r00t;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            conn.Open();

            Console.WriteLine("Which country do you want me to search?");
            string givenCountry = Console.ReadLine();
            cmd.CommandText = "SELECT Code, Name, Continent, Region FROM country WHERE name LIKE @givenCountry";
            cmd.Parameters.AddWithValue("@givenCountry", "%" + givenCountry + "%");

            
            var reader = cmd.ExecuteReader();
        }
        
    }
}
