
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HelloWorld.Dapper
{

    public class Data
    {
        string dbConnectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=false;User Id=sa; Password=SQLConnect1";

        public IEnumerable<T> QueryMultiple<T>(string queryString)
        {
            IDbConnection dbConnection = new SqlConnection(dbConnectionString);

            return dbConnection.Query<T>(queryString);
        }

        public T QuerySingle<T>(string queryString)
        {
            IDbConnection dbConnection = new SqlConnection(dbConnectionString);

            return dbConnection.QuerySingle<T>(queryString);
        }

        public bool LoadData(string queryString)
        {
            IDbConnection dbConnection = new SqlConnection(dbConnectionString);
           return ( dbConnection.Execute(queryString) > 0);
        }

        public int LoadAndCountData(string queryString)
        {
            IDbConnection dbConnection = new SqlConnection(dbConnectionString);

            return dbConnection.Execute(queryString);

        }
    }

}
    
