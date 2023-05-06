using System;
using System.Data;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string dbConnectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=false;User Id=sa; Password=SQLConnect1";


            IDbConnection databaseConnection = new SqlConnection(dbConnectionString);

            string query = "SELECT GETDATE()";

            DateTime current = databaseConnection.QuerySingle<DateTime>(query);

            Console.WriteLine("This is the current date: " + current);

            Computer myComputer = new Computer()
            {
                Motherboard = "ZBHSD",
                CPUCores = 5,
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 34.4343m,
                VideoCard = "Mac Pro VideoCard"
            };



            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                CPUCores,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard

                ) VALUES ('"+ myComputer.Motherboard
                            + "', '" + myComputer.CPUCores
                            + "', '" + myComputer.HasWifi
                            + "', '" + myComputer.HasLTE
                            + "', '" + myComputer.ReleaseDate
                            + "', '" + myComputer.Price
                            + "', '" + myComputer.VideoCard
                            + "')";

            Console.WriteLine(sql);

            int result = databaseConnection.Execute(sql);
            Console.WriteLine(result);


            string selectStatement = @"

             SELECT
                Computer.Motherboard,
                Computer.CPUCores,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = databaseConnection.Query<Computer>(selectStatement);

            foreach(Computer computer in computers)
            {
                Console.WriteLine("'"
                    + myComputer.Motherboard
                            + "', '" + computer.CPUCores
                            + "', '" + computer.HasWifi
                            + "', '" + computer.HasLTE
                            + "', '" + computer.ReleaseDate
                            + "', '" + computer.Price
                            + "', '" + computer.VideoCard
                            +
                            "'");

            }


           



            //Console.WriteLine(myComputer.Motherboard);
            //Console.WriteLine(myComputer.CPUCores);
            //Console.WriteLine(myComputer.HasWifi);
            //Console.WriteLine(myComputer.HasLTE);
            //Console.WriteLine(myComputer.ReleaseDate);
            //Console.WriteLine(myComputer.Price);
            //Console.WriteLine(myComputer.VideoCard);

        }

    }
}