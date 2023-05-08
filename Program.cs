using System;
using System.Data;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DapperDataContext dapperContext = new DapperDataContext();
            EntityFrameowrkContext efDataContext = new EntityFrameowrkContext();

            string query = "SELECT GETDATE()";

            DateTime current = dapperContext.QuerySingle<DateTime>(query);

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

            //Using Entity Framework
            efDataContext.Computer.Add(myComputer);
            efDataContext.SaveChanges();


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

            //Using Dapper
            bool result = dapperContext.LoadData(sql);
            int count = dapperContext.LoadAndCountData(sql);

            Console.WriteLine(result);



            //Select
            string selectStatement = @"

             SELECT
                Computer.Motherboard,
                Computer.ComputerId,    
                Computer.CPUCores,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard FROM TutorialAppSchema.Computer";

            //Using Dapper
            IEnumerable<Computer> computers = dapperContext.QueryMultiple<Computer>(selectStatement);

            //Using Entity Framework
            IEnumerable<Computer> efComputers  = efDataContext.Computer.ToList<Computer>();

      foreach (Computer computer in computers)
            {
                Console.WriteLine("'"
                    + myComputer.Motherboard
                            + "', '" + computer.ComputerId
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